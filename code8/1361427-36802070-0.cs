        To check if particular line is wrapped or not, here is the GDI Function you need to use:
        1. [DllImport("user32.dll")]
        static extern int DrawText(IntPtr hdc, string lpStr, int nCount, ref Dimension lpRect, int wFormat);
        
        Here are what you need to get things done:
          public enum DrawTextFlags
            {
                CalculateArea = 0x00000400,
                WordBreak = 0x00000010,
                TextBoxControl = 0x00002000,
                Top = 0x00000000,
                Left = 0x00000000,
                HorizontalCenter = 0x00000001,
                Right = 0x00000002,
                VerticalCenter = 0x00000004,
                Bottom = 0x00000008,
                SingleLine = 0x00000020,
                ExpandTabs = 0x00000040,
                TabStop = 0x00000080,
                NoClipping = 0x00000100,
                ExternalLeading = 0x00000200,
                NoPrefix = 0x00000800,
                Internal = 0x00001000,
                PathEllipsis = 0x00004000,
                EndEllipsis = 0x00008000,
                WordEllipsis = 0x00040000,
                ModifyString = 0x00010000,
                RightToLeft = 0x00020000,
                NoFullWidthCharacterBreak = 0x00080000,
                HidePrefix = 0x00100000,
                PrefixOnly = 0x00200000,
                NoPadding = 0x10000000,
            }
            [StructLayout(LayoutKind.Sequential)]
            public struct Dimension
            {
                public int Left, Top, Right, Bottom;
        
                public Dimension(int left, int top, int right, int bottom)
                {
                    this.Left = left;
                    this.Right = right;
                    this.Top = top;
                    this.Bottom = bottom;
                }
                public Dimension(Rectangle r)
                {
                    this.Left = r.Left;
                    this.Top = r.Top;
                    this.Bottom = r.Bottom;
                    this.Right = r.Right;
                }
                public static implicit operator Rectangle(Dimension rc)
                {
                    return Rectangle.FromLTRB(rc.Left, rc.Top, rc.Right, rc.Bottom);
                }
                public static implicit operator Dimension(Rectangle rc)
                {
                    return new Dimension(rc);
                }
        
                public static Dimension Default
                {
                    get { return new Dimension(0, 0, 1, 1); }
                }
            }
    
    So to know whether a particular line is wrapped or not, you would call the function like this:
    Dimension rc = new Dimension(0,0,2,2);
    var flag =  DrawTextFlags.CalculateArea | DrawTextFlags.TextBoxControl | DrawTextFlags.WordBreak;
    DrawText(hdc, line, line.length, ref rc, (int)flag);
    Now if height of rc you get after executing this function is greater then your font height or tmHeight if you use TextMetric (that is what minimum required for a line to fit vertically) you can safely assume your line is wrapped.
    Apart from this,
    You can use the following function as an alternative approach:
    static extern bool GetTextExtentExPoint(IntPtr hDc, string str, int nLength,
                int nMaxExtent, int[] lpnFit, int[] alpDx, ref Size size);
