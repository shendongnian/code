    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Text;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
    
            static void Main()
            {
                Color color = Char2Color('A');
                char ch = Color2Char(color);
    
            }
    
            static char Color2Char(Color c)
            {
                Byte[] result = {0xff,0xff};
    
                var red = (c.R >> 3) ;
                var green = (c.G >> 3) ;
                var blue = (c.B >> 2);
    
                result[0] = (byte)(red << 3);
                result[0] = (byte)(result[0] + (green >> 2));
                result[1] = (byte)(green << 6);
                result[1] = (byte)(result[1] + blue);
                Array.Reverse(result);
                return BitConverter.ToChar(result,0);
            }
    
            static Color Char2Color(char ch)
            {
                const int RedMask = 0xF8;
                const int GreenMask = 0xF8;
                const int BlueMask = 0xFC;
                const int RedShift = 8;
                const int GreenShift = 3;
                const int BlueShift = 2;
    
                int val = ch;
                int r = (val >> RedShift) & RedMask;
                int g = (val >> GreenShift) & GreenMask;
                int b = (val << BlueShift) & BlueMask;
    
                return Color.FromArgb(r, g, b);
            }
    
        }
    }
