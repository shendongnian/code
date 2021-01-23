    using System;
    using System.Drawing;
    class Program
    {
        public static Color COLOR_TEXT = Color.Red;
        public static Color COLOR_BACK = Color.White;
        static void Main(string[] args)
        {
            var font = new Font(FontFamily.GenericMonospace, 35);
            var image = DrawClass.DrawText2("Stack Overflow\r\n\tby jp2code", font, COLOR_TEXT, COLOR_BACK);
            image.Save("C:\\jp2code.bmp");
        }
        public static Image DrawText2(String text, Font font, Color textColor, Color backColor)
        {
            var textSize = GetTextSize(text, font);
            var result = new Bitmap((int)textSize.Width, (int)textSize.Height);
            using (var g = Graphics.FromImage(result))
            {
                g.Clear(backColor);
                var brush = new SolidBrush(textColor);
                g.DrawString(text, font, brush, 0, 0);
                g.Save();
            }
            return result;
        }
        public static SizeF GetTextSize(String text, Font font)
        {
            using (var img = new Bitmap(200, 100))
            {
                using (var g = Graphics.FromImage(img))
                {
                    return g.MeasureString(text, font);
                }
            }
        }
    }
