    static void Main(string[] args)
            {
                var image = new Bitmap(1000, 500);
    
                var g = Graphics.FromImage(image);
                g.FillRectangle(System.Drawing.Brushes.White, 0, 0, 1000, 500);
    
                var stringFormat = new StringFormat(StringFormat.GenericTypographic) {
                     Alignment = StringAlignment.Near,
                     FormatFlags = System.Drawing.StringFormatFlags.LineLimit | System.Drawing.StringFormatFlags.NoClip | StringFormatFlags.DirectionRightToLeft
                };
    
                var font = new Font(new System.Drawing.FontFamily("Times New Roman"), 72.0f,FontStyle.Regular, GraphicsUnit.Point);
                var point = new PointF { X = 10, Y = 10 };
    
                SizeF[] outputs = new SizeF[7];
                SizeF[] total = new SizeF[7];
                outputs[0] = g.MeasureString("T", font, point, stringFormat);
                outputs[1] = g.MeasureString("e", font, point, stringFormat);
                outputs[2] = g.MeasureString("s", font, point, stringFormat);
                outputs[3] = g.MeasureString("t", font, point, stringFormat);
                outputs[4] = g.MeasureString("S", font, point, stringFormat);
                outputs[5] = g.MeasureString("t", font, point, stringFormat);
                outputs[6] = g.MeasureString("r", font, point, stringFormat);
    
                total[0] = g.MeasureString("T", font, point, stringFormat);
                total[1] = g.MeasureString("Te", font, point, stringFormat);
                total[2] = g.MeasureString("Tes", font, point, stringFormat);
                total[3] = g.MeasureString("Test", font, point, stringFormat);
                total[4] = g.MeasureString("TestS", font, point, stringFormat);
                total[5] = g.MeasureString("TestSt", font, point, stringFormat);
                total[6] = g.MeasureString("TestStr", font, point, stringFormat);
    
                stringFormat.FormatFlags = System.Drawing.StringFormatFlags.LineLimit | System.Drawing.StringFormatFlags.NoClip;
    
                g.DrawString("TestStr", font, System.Drawing.Brushes.Red, new PointF { X = 10, Y = 10 }, stringFormat);
                g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Brushes.Blue, 1.0f), GetOutputPositionX(total,outputs, 0), 10.0f, outputs[0].Width, outputs[0].Height);
                g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Brushes.Blue, 1.0f), GetOutputPositionX(total,outputs, 1), 10.0f, outputs[1].Width, outputs[1].Height);
                g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Brushes.Blue, 1.0f), GetOutputPositionX(total,outputs, 2), 10.0f, outputs[2].Width, outputs[2].Height);
                g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Brushes.Blue, 1.0f), GetOutputPositionX(total,outputs, 3), 10.0f, outputs[3].Width, outputs[3].Height);
                g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Brushes.Blue, 1.0f), GetOutputPositionX(total,outputs, 4), 10.0f, outputs[4].Width, outputs[4].Height);
                g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Brushes.Blue, 1.0f), GetOutputPositionX(total,outputs, 5), 10.0f, outputs[5].Width, outputs[5].Height);
                g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Brushes.Blue, 1.0f), GetOutputPositionX(total,outputs, 6), 10.0f, outputs[6].Width, outputs[6].Height);
    
                image.Save(@"c:\Temp\bla.png");
    
            }
            private static float GetOutputPositionX(SizeF[] total, SizeF[] outputs, int p)
            {
                return 10.0f + total[p].Width - outputs[p].Width;
            }
