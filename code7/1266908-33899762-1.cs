        public void Print()
        {
            this.InitPrintDocument();
            using (System.Windows.Forms.PrintDialog dlg = new System.Windows.Forms.PrintDialog())
            {
                dlg.AllowSomePages = false;
                dlg.AllowSelection = false;
                dlg.AllowPrintToFile = false;
                dlg.AllowCurrentPage = false;
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this._printDoc.PrinterSettings = dlg.PrinterSettings;
                    this._printDoc.Print();
                }
            }
        }
        private void InitPrintDocument()
        {
            if (this._printDoc != null)
                this._printDoc.Dispose();
            this._printDoc = new System.Drawing.Printing.PrintDocument();
            this._printDoc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_onBeginPrint);
            this._printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_onPrintPage);
        }
        private void printDocument_onBeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this._lastPrintLine = 0;
        }
        private void printDocument_onPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string pgTxt = "";
            this.SuspendRefresh();
            this.SuspendScroll();
            int stChar = this.GetFirstCharIndexFromLine(this._lastPrintLine),
                stLn = this._lastPrintLine,
                selStart = this.SelectionStart,
                selLength = this.SelectionLength;
            try
            {
                using (StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit))
                {
                    int lnCnt = this.Lines.Length;
                    SizeF lnNumSz = e.Graphics.MeasureString("0000", this.Font);
                    float numMarginWidth = lnNumSz.Width + 2.0f;
                    while (e.Graphics.MeasureString(pgTxt, this.Font, new Size(e.MarginBounds.Size.Width - (int)numMarginWidth, e.MarginBounds.Size.Height), fmt).Height < e.MarginBounds.Height - (e.MarginBounds.Top / 2) && this._lastPrintLine < this.Lines.Length)
                        pgTxt += ((pgTxt.Length > 0) ? "\n" : "") + this.Lines[this._lastPrintLine++];
                    bool newLine = true;
                    PointF nextCharPos = new PointF((float)e.MarginBounds.Left + numMarginWidth, (float)e.MarginBounds.Top);
                    RectangleF numMarginBounds = new RectangleF((float)e.MarginBounds.Left, (float)e.MarginBounds.Top, numMarginWidth, (float)e.MarginBounds.Height);
                    using (SolidBrush numBrush = new SolidBrush(Color.FromArgb(200, 200, 200)))
                        e.Graphics.FillRectangle(numBrush, numMarginBounds);
                    for (int i = 0; i < pgTxt.Length; i++)
                    {
                        this.SelectionStart = stChar + i;
                        if (newLine)
                        {
                            RectangleF numRect = new RectangleF(e.MarginBounds.Left, nextCharPos.Y, numMarginWidth, lnNumSz.Height);
                            using (StringFormat format = new StringFormat(StringFormatFlags.NoWrap))
                            {
                                format.Alignment = StringAlignment.Far;
                                e.Graphics.DrawString(Convert.ToString(this.GetLineFromCharIndex(stChar + i) + 1), this.Font, Brushes.DarkGreen, numRect, format);
                            }
                        }
                        string nextChar = pgTxt.Substring(i, 1);
                        if (nextChar != "\n")
                        {
                            SelectionLength = 1;
                            Color curCol = this.SelectionColor;
                            SizeF charSz = e.Graphics.MeasureString(nextChar, this.Font);
                            if (nextCharPos.X + (charSz.Width / 1.5) > (e.MarginBounds.Width / 0.9))
                                nextCharPos = new PointF((float)e.MarginBounds.Left + numMarginWidth, nextCharPos.Y + (charSz.Height / 1.105f));
                            using (SolidBrush brush = new SolidBrush(curCol))
                                e.Graphics.DrawString(nextChar, this.Font, brush, nextCharPos);
                            nextCharPos = new PointF(nextCharPos.X + charSz.Width / ((nextChar != " ") ? 1.5f : 0.9f), nextCharPos.Y);
                            newLine = false;
                        }
                        else
                        {
                            newLine = true;
                            SizeF charSz = e.Graphics.MeasureString("W", this.Font);
                            nextCharPos = new PointF((float)e.MarginBounds.Left + numMarginWidth, nextCharPos.Y + (charSz.Height / 1.105f));
                        }
                    }
                    e.HasMorePages = (this._lastPrintLine < this.Lines.Length);
                    if (!e.HasMorePages)
                    {
                        e.Graphics.FillRectangle(Brushes.White, new RectangleF(0.0f, nextCharPos.Y + lnNumSz.Height, e.PageBounds.Width, e.MarginBounds.Bottom - (nextCharPos.Y + lnNumSz.Height)));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, "Unable to generate page for printing:\n\n" + ex.Message, "Unexpected Error");
            }
            finally
            {
                this.SelectionStart = selStart;
                this.SelectionLength = selLength;
                this.ResumeScroll();
                this.ResumeRefresh();
            }
        }
