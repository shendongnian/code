    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Menu = null;
            DrawText(e.Graphics, "اسمي مصير الطفل. من أي بلد أنت", Font, ClientRectangle);
        }
        private void DrawText(Graphics g, string text, Font font, Rectangle rectangle)
        {
            IntPtr dc = g.GetHdc();
            RECT rect = (RECT)rectangle;
            IntPtr hFont = IntPtr.Zero;
            IntPtr previousFont = IntPtr.Zero;
            try
            {
                hFont = font.ToHfont();
                previousFont = SelectObject(dc, hFont);
                DrawText(dc, text, text.Length, ref rect, DrawTextFlags.RightToLeft | DrawTextFlags.Right | DrawTextFlags.WordBreak);
            }
            finally
            {
                if (previousFont != IntPtr.Zero)
                {
                    SelectObject(dc, previousFont);
                }
                if (hFont != IntPtr.Zero)
                {
                    DeleteObject(hFont);
                }
                g.ReleaseHdc(dc);
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            internal int Left;
            internal int Top;
            internal int Right;
            internal int Bottom;
            public static explicit operator RECT(Rectangle rect)
            {
                return new RECT()
                {
                    Left = rect.Left,
                    Top = rect.Top,
                    Right = rect.Right,
                    Bottom = rect.Bottom
                };
            }
        }
        [DllImport("coredll.dll", CharSet = CharSet.Unicode)]
        internal static extern int DrawText(IntPtr hdc, string lpStr, int nCount, ref RECT lpRect, DrawTextFlags flags);
        [DllImport("coredll.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteObject([In] IntPtr hObject);
        [DllImport("coredll.dll")]
        internal static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        [Flags]
        public enum DrawTextFlags : uint
        {
            /// <summary>
            /// Use default values.
            /// </summary>
            None = 0x00000000,
            /// <summary>
            /// Justifies the text to the top of the rectangle.
            /// </summary>
            Top = 0x00000000,
            /// <summary>
            /// Aligns text to the left.
            /// </summary>
            Left = 0x00000000,
            /// <summary>
            /// Centers text horizontally in the rectangle.
            /// </summary>
            Center = 0x00000001,
            /// <summary>
            /// Aligns text to the right.
            /// </summary>
            Right = 0x00000002,
            /// <summary>
            /// Centers text vertically. This value is used only with the SingleLine value.
            /// </summary>
            VerticalCenter = 0x00000004,
            /// <summary>
            /// Justifies the text to the bottom of the rectangle. This value is used only with the 
            /// SingleLine value.
            /// </summary>
            Bottom = 0x00000008,
            /// <summary>
            /// Breaks words. Lines are automatically broken between words if a word would extend past the 
            /// edge of the rectangle specified by the lpRect parameter. A carriage return-line feed sequence 
            /// also breaks the line. If this is not specified, output is on one line.
            /// </summary>
            WordBreak = 0x00000010,
            /// <summary>
            /// Displays text on a single line only. Carriage returns and line feeds do not break the line.
            /// </summary>
            SingleLine = 0x00000020,
            /// <summary>
            /// Expands tab characters. The default number of characters per tab is eight. 
            /// </summary>
            ExpandTabs = 0x00000040,
            /// <summary>
            /// Sets tab stops. Bits 15-8 (high-order byte of the low-order word) of the uFormat parameter 
            /// specify the number of characters for each tab. The default number of characters per tab is 
            /// eight. 
            /// </summary>
            Tabstop = 0x00000080,
            /// <summary>
            /// Draws without clipping. 
            /// </summary>
            NoClip = 0x00000100,
            /// <summary>
            /// Includes the font external leading in line height. Normally, external leading is not included 
            /// in the height of a line of text.
            /// </summary>
            ExternalLeading = 0x00000200,
            /// <summary>
            /// Determines the width and height of the rectangle. If there are multiple lines of text, DrawText 
            /// uses the width of the rectangle pointed to by the lpRect parameter and extends the base of the 
            /// rectangle to bound the last line of text. If the largest word is wider than the rectangle, the 
            /// width is expanded. If the text is less than the width of the rectangle, the width is reduced. 
            /// If there is only one line of text, DrawText modifies the right side of the rectangle so that it 
            /// bounds the last character in the line. In either case, DrawText returns the height of the 
            /// formatted text but does not draw the text.
            /// </summary>
            CalcRect = 0x00000400,
            /// <summary>
            /// Turns off processing of prefix characters. Normally, DrawText interprets the mnemonic-prefix 
            /// character & as a directive to underscore the character that follows, and the mnemonic-prefix 
            /// characters && as a directive to print a single &. By specifying DT_NOPREFIX, this processing 
            /// is turned off. 
            /// </summary>
            NoPrefix = 0x00000800,
            /// <summary>
            /// Uses the system font to calculate text metrics.
            /// </summary>
            Internal = 0x00001000,
            /// <summary>
            /// Duplicates the text-displaying characteristics of a multiline edit control. Specifically, 
            /// the average character width is calculated in the same manner as for an edit control, and 
            /// the function does not display a partially visible last line.
            /// </summary>
            EditControl = 0x00002000,
            /// <summary>
            /// For displayed text, if the end of a string does not fit in the rectangle, it is truncated 
            /// and ellipses are added. If a word that is not at the end of the string goes beyond the 
            /// limits of the rectangle, it is truncated without ellipses.
            /// </summary>
            EndEllipsis = 0x00008000,
            /// <summary>
            /// Layout in right-to-left reading order for bidirectional text when the font selected into the 
            /// hdc is a Hebrew or Arabic font. The default reading order for all text is left-to-right.
            /// </summary>
            RightToLeft = 0x00020000,
            /// <summary>
            /// Truncates any word that does not fit in the rectangle and adds ellipses. 
            /// </summary>
            WordEllipsis = 0x00040000
        }
    }
