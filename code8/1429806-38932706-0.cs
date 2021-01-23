        private void textBox1_SizeChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Height < 10) return;
            if (tb == null) return;
            if (tb.Text == "") return;
            SizeF stringSize;
            // create a graphics object for this form
            using (Graphics gfx = this.CreateGraphics())
            {
                // Get the size given the string and the font
                stringSize = gfx.MeasureString(tb.Text, tb.Font);
                //test how many rows
                int rows = (int)((double)tb.Height / (stringSize.Height));
                if (rows == 0)
                    return;
                double areaAvailable = rows * stringSize.Height * tb.Width;
                double areaRequired = stringSize.Width * stringSize.Height * 1.1;
                if (areaAvailable / areaRequired > 1.3)
                {
                    while (areaAvailable / areaRequired > 1.3)
                    {
                        tb.Font = new Font(tb.Font.FontFamily, tb.Font.Size * 1.1F);
                        stringSize = gfx.MeasureString(tb.Text, tb.Font);
                        areaRequired = stringSize.Width * stringSize.Height * 1.1;
                    }
                }
                else
                {
                    while (areaRequired * 1.3 > areaAvailable)
                    {
                        tb.Font = new Font(tb.Font.FontFamily, tb.Font.Size / 1.1F);
                        stringSize = gfx.MeasureString(tb.Text, tb.Font);
                        areaRequired = stringSize.Width * stringSize.Height * 1.1;
                    }
                }
            }
        }
