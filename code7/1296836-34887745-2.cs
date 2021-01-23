    public bool Redact(List<Rect> redactions, List<System.Windows.Media.Color> redactionColors, System.Windows.Media.Matrix matrix, int pageNum)
        {
            if (pageNum >= 0 && pageNum < totalPageCount && redactions.Count > 0 && redactions.Count == redactionColors.Count)
            {
                PdfDocument currDoc = PdfReader.Open(fullPath, PdfDocumentOpenMode.Modify);
                int angle = currDoc.Pages[pageNum].Rotate;
                PdfPage oldPage = currDoc.Pages[pageNum];
                XBrush brush = null;
                XGraphics gfx = XGraphics.FromPdfPage(oldPage);
                XPoint pagePoint = new XPoint(0, 0);
                if (angle == 180)
                {
                    pagePoint.X = oldPage.Width / 2;
                    pagePoint.Y = oldPage.Height / 2;
                    gfx.RotateAtTransform(180, pagePoint);
                }
                for (int i = 0; i < redactions.Count; i++)
                {
                    Rect redaction = redactions[i];
                    System.Windows.Media.Color redactionColor = redactionColors[i];
                    double scaleValue = oldPage.Height / matrix.OffsetX;
                    if (angle == 180 || angle == 0)
                    {
                        redaction.X = redaction.X / (matrix.OffsetX / oldPage.Width);
                        redaction.Y = redaction.Y / (matrix.OffsetY / oldPage.Height);
                        redaction.Width = redaction.Width / (matrix.OffsetX / oldPage.Width);
                        redaction.Height = redaction.Height / (matrix.OffsetY / oldPage.Height);
                        redaction.Width = redaction.Width / matrix.M11;
                        redaction.Height = redaction.Height / matrix.M12;
                    }
                    else if (angle == 90 || angle == 270)
                    {
                        Rect tempRect = redaction;
                        
                        tempRect.X = redaction.X * scaleValue;
                        tempRect.Y = redaction.Y * scaleValue;
                        tempRect.Height = redaction.Height * scaleValue;
                        tempRect.Width = redaction.Width * scaleValue;
                        redaction.Width = tempRect.Height;
                        redaction.Height = tempRect.Width;
                        tempRect.Width = tempRect.Width / matrix.M11;
                        tempRect.Height = tempRect.Height / matrix.M12;
                        redaction.X = oldPage.Width - tempRect.Y - tempRect.Height;
                        redaction.Y = tempRect.X;
                        if (angle == 90)
                            gfx.RotateAtTransform(180, new XPoint(oldPage.Width / 2, oldPage.Height / 2));
                        redaction.Width = tempRect.Height;
                        redaction.Height = tempRect.Width;
                    }
                    brush = new XSolidBrush(XColor.FromArgb(redactionColor.A, redactionColor));
                    gfx.DrawRectangle(brush, redaction);
                }
                gfx.Save();
                currDoc.Save(fullPath);
                return true;
            }
            else
                return false;
        }
