    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace HowToHighlightPortionOfText
    {
        public static class Helper
        {
            private static Rectangle dummy
            {
                get
                {
                    return new Rectangle(0, 0, 10, 10);
                }
            }
            const uint H = 0x00000000;
            const uint V = 0x00000001;
            const uint T = 0x00000002;
    
            #region api functions
            [DllImport("user32.dll")]
            static extern int DrawText(IntPtr hdc, string lpStr, int nCount, ref Dimension lpRect, int wFormat);
    
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(this IntPtr hdc, IntPtr hObject);
    
            [DllImport("gdi32.dll")]
            public static extern int DeleteObject(this IntPtr hObject);
    
            [DllImport("gdi32.dll", EntryPoint = "GdiGradientFill", ExactSpelling = true)]
            static extern bool GradientFill(IntPtr hdc, Trivertex[] pVertex,
                uint dwNumVertex, uint[] pMesh, uint dwNumMesh, uint dwMode);
    
            [DllImport("gdi32")]
            public static extern int SetBkMode(this IntPtr hdc, int nBkMode);
    
            [DllImport("gdi32.dll")]
            public static extern uint SetTextColor(this IntPtr hdc, int crColor);
    
            [DllImport("gdi32.dll")]
            public static extern uint SetBkColor(this IntPtr hdc, int crColor);
            #endregion
    
            #region public methods
            //use this function to hilight portion of listbox item text
            public static void HilightItemText(this ListBox control, int itemIndex, int startIndex, int endIndex,
                 Color highlightForeColor, Color highlightBackColorStart,  Color? highlightBackColorEnd = null)
            {
                var container = control.GetItemRectangle(itemIndex);
                var text = control.GetItemText(itemIndex);
    
                using (Graphics g = control.CreateGraphics())
                {
                    g.HighlightText(control.Font, text, container, startIndex, endIndex,
                        highlightForeColor, highlightBackColorStart, highlightBackColorEnd);
    
                }
            }
    
            public static void HighlightText(this IDeviceContext dc, Font font, string text,
               Rectangle container, int start, int end, Color highlightForeColor, Color highlightBackColorStart, 
               Color? highlightBackColorEnd, DrawTextFlags? flags = null)
            {
                IntPtr hdc = dc.GetHdc();
                IntPtr _font = SelectObject(hdc, font.ToHfont());
    
                Dimension dm = container;
                var flag = flags.getMeasureFlag(false);
    
                SetBkMode(hdc, ColorTranslator.ToWin32(Color.Transparent));
    
                //first draw whole text
                DrawText(hdc, text, text.Length, ref dm, 0);
    
                //now get the highlight rectangle which will draw the highlighted text
                Rectangle textBound, uptoIndex;
                var rect = hdc.rangeBound(text, container, start, end, out textBound, out uptoIndex, flags: flags);
                dm = rect;
    
                var _backColorEnd = highlightBackColorEnd ?? highlightBackColorStart;
                hdc.Fill(rect, highlightBackColorStart, _backColorEnd, Angle.A0);
    
                SetTextColor(hdc, ColorTranslator.ToWin32(highlightForeColor));
    
                if (start < 0 || start > text.Length - 1 || end < 0 || end > text.Length - 1)
                    throw new Exception("start and end value must be with in text length");
    
                var _text = text.Substring(start, end - start + 1);
                DrawText(hdc, _text, _text.Length, ref dm, 0);
    
                DeleteObject(SelectObject(hdc, _font));
                dc.ReleaseHdc();
            }
    
            public static Rectangle RangeBound(this IDeviceContext dc, Font font, string text,
               Rectangle container, int start, int end, DrawTextFlags? flags = null)
            {
                Rectangle textBound, uptoIndex;
                return dc.RangeBound(font, text, container, start, end, out textBound, out uptoIndex, flags);
            }
    
            public static Rectangle GetPortionRectangleToHighlight(this ListBox control, int itemIndex, int startIndex, int endIndex)
            {
                var container = control.GetItemRectangle(itemIndex);
                var text = control.GetItemText(itemIndex);
                Rectangle rect;
    
                using (Graphics g = control.CreateGraphics())
                {
                    rect = g.RangeBound(control.Font, text, container, startIndex, endIndex);
    
                }
                return rect;
            }
    
            public static bool Fill(this IntPtr hdc, Rectangle rc, Color c1,
               Color c2, Angle angle)
            {
                return hdc.Fill(rc.X, rc.Y, rc.Right, rc.Bottom, c1, c2, angle);
            }
    
            public static bool Fill(this IntPtr hdc, int x0, int y0, int x1, int y1, Color c1, Color c2, Angle angle)
            {
                Trivertex[] t = new Trivertex[4]
                {
                    new Trivertex(x0, y0, c1),
                    new Trivertex(x1, y1, c2),
                    new Trivertex(x0, y1, c1, c2),
                    new Trivertex(x1, y0, c1, c2)
                };
                uint[] pMesh = new uint[] { 0, 1, 2, 0, 1, 3 };
    
                switch ((int)angle % 180)
                {
                    case 0:
                        return GradientFill(hdc, t, 2, pMesh, 1, H);
                    case 45:
                        return GradientFill(hdc, t, 4, pMesh, 2, T);
                    case 90:
                        return GradientFill(hdc, t, 2, pMesh, 1, V);
                    case 135:
                        t[0].x = x1;
                        t[3].x = x0;
                        t[1].x = x0;
                        t[2].x = x1;
                        return GradientFill(hdc, t, 4, pMesh, 2, T);
                    default:
                        return false;
                }
            }
    
            #endregion
    
            #region get the highlight rectangle
            static Rectangle RangeBound(this IDeviceContext dc, Font font, string text,
                Rectangle container, int start, int end, out Rectangle textBound, out Rectangle uptoIndex, DrawTextFlags? flags = null)
            {
                textBound = Rectangle.Empty;
                uptoIndex = Rectangle.Empty;
    
                if (string.IsNullOrEmpty(text)) return Rectangle.Empty;
    
                IntPtr hdc = dc.GetHdc();
                IntPtr _font = SelectObject(hdc, font.ToHfont());
    
                var rc = hdc.rangeBound(text, container, start, end, out textBound, out uptoIndex, flags: flags);
    
                DeleteObject(SelectObject(hdc, _font));
                dc.ReleaseHdc();
                return rc;
            }
            
            static TextMeasurement charRectangle(this IntPtr hdc, string text, Rectangle container,
                string wholeText = null, Point? point = null, bool adjustByPoint = false, DrawTextFlags? flags = null)
            {
                if (string.IsNullOrEmpty(text)) return TextMeasurement.Default;
    
                TextMeasurement measurement = new TextMeasurement();
                Rectangle textBound;
    
                wholeText = (wholeText ?? text);
    
                var location = container.Location;
    
                var measureWholeText = point == null;
                measurement.UserPoint = point ?? Point.Empty;
    
    
                textBound = hdc.textBound(wholeText, container, flags: flags);
    
                var rect = textBound;
                var p = point ?? new Point(container.Right, container.Y);
    
                if (!measureWholeText)
                {
                    if (p.X > textBound.Right)
                        p.X = textBound.Right;
                    else if (p.X < textBound.Left)
                        p.X = textBound.X;
                }
    
                var charIndex = 0;
    
                var result = hdc.charRectangle(text, ref p, rect, flags, measureWholeText);
    
                charIndex = Math.Max(0, result.Item2);
                var rectangles = result.Item1;
    
                measurement.Bounds = rectangles[0];
                measurement.TextBounds = (measureWholeText) ? rectangles[1] : textBound;
                rectangles[1] = measurement.TextBounds;
    
                if (!measureWholeText && adjustByPoint && charIndex > 0)
                {
                    float middle = (float)measurement.Bounds.Left +
                        measurement.Bounds.Width / 2;
                    if (p.X > middle - 1)
                    {
                        Rectangle r;
                        Dimension r1 = measurement.TextBounds;
    
                        var newresult = hdc.charBound(text, charIndex + 2, ref r1,
                            (int)flags.getMeasureFlag(false), out r);
    
                        if (!newresult.Equals(measurement.Bounds) &&
                            newresult.X > measurement.Bounds.X)
                        {
                            charIndex++;
                            measurement.Bounds = newresult;
                        }
                    }
                }
                if (measurement.Bounds.Size.Width<=0)
                    measurement.Bounds = new Rectangle(measurement.Bounds.Location, new Size(2, 2));
    
                measurement.CharIndex = charIndex;
                measurement.Char = '\0';
                measurement.Char = text[Math.Min(charIndex, text.Length - 1)];
                return measurement;
            }
    
            static Tuple<Rectangle[], int> charRectangle(this IntPtr hdc, string text, ref Point p, Rectangle rect,
                 DrawTextFlags? flags, bool measureWholeText = false)
            {
                int i = 0;
    
                int middle = text.Length / 2, start = 0;
                bool first = true;
                do
                {
                    var upto = hdc.Measure(text.Substring(0, middle), null, rect, flags);
                    bool found = upto.Has(p);
                    if (!found)
                    {
                        start = middle;
                        middle += (text.Length - middle) / 2;
                        first = false;
                        if (start == middle) break;
                    }
                    else break;
                } while (middle > 1 && text.Length - middle > 1);
    
                if (first)
                {
                    return hdc.charRectangle(text.Substring(0, middle),
                        ref p, rect, flags);
                }
                else
                {
                    Rectangle[] list = new Rectangle[2];
                    for (i = start; i <= middle; i++)
                    {
                        if (hdc.Measure(text, out list, p, i + 1, rect, flags))
                            break;
                    }
                    i = Math.Max(i, 0);
                    return new Tuple<Rectangle[], int>(list, i);
                }
            }
    
            static Rectangle charBound(this IntPtr hdc, string text, int len,
               ref Dimension bounds, int flag, out Rectangle whole)
            {
                DrawText(hdc, text, len, ref bounds, flag);
                whole = bounds;
                var rc = bounds;
                if (len - 1 > 0 && len <= text.Length)
                {
                    DrawText(hdc, text.Substring(0, len - 1), len - 1, ref rc, flag);
                    rc = Rectangle.FromLTRB(rc.Right, bounds.Top, bounds.Right, bounds.Bottom);
                }
                return rc;
            }
    
           static Rectangle rangeBound(this IntPtr hdc, string text, Rectangle container, int start, int end,
                out Rectangle textBound, out Rectangle uptoIndex,   DrawTextFlags? flags = null)
            {
                textBound = Rectangle.Empty;
                uptoIndex = Rectangle.Empty;
    
                if (string.IsNullOrEmpty(text)) return Rectangle.Empty;
    
                var location = container.Location;
                textBound = hdc.textBound(text, container, flags);
    
                Dimension rect = textBound;
                var flag = flags.getMeasureFlag(false);
    
                start++;
                var text1 = text.Substring(0, start);
                var rc = hdc.charBound(text1, text1.Length, ref rect, (int)flag, out uptoIndex);
    
                end++;
                var text2 = text.Substring(0, end);
                DrawText(hdc, text2, text2.Length, ref rect, (int)flag);
    
                return Rectangle.FromLTRB(rc.Left, rect.Top, rect.Right, rect.Bottom);
            }
    
            static Rectangle textBound(this IntPtr hdc, string text, Rectangle container,  DrawTextFlags? flags = null)
            {
                Rectangle rc = Rectangle.Empty;
    
                if (string.IsNullOrEmpty(text)) return rc;
                Point p = container.Location;
    
                var r = hdc.Measure(text, text.Length, flags: flags);
                return new Rectangle(p, r.Size);
            }
    
    
            static DrawTextFlags getMeasureFlag(this DrawTextFlags? flags, bool textboxControl = false)
            {
                DrawTextFlags flag = DrawTextFlags.CalculateArea;
                if (flags != null) flag |= flags.Value;
    
                flag |= DrawTextFlags.WordBreak | DrawTextFlags.NoPrefix
                    | DrawTextFlags.NoPadding | DrawTextFlags.NoClipping;
    
                if (textboxControl) flag |= DrawTextFlags.TextBoxControl;
                else flag |= DrawTextFlags.SingleLine;
                return flag;
            }
    
            static Rectangle RangeBound(this IntPtr hdc, string text,
               Rectangle container, int start, int end, DrawTextFlags? flags = null)
            {
                Rectangle textBound, uptoIndex;
                return hdc.rangeBound(text, container, start, end, out textBound, out uptoIndex, flags);
            }
    
            static Rectangle Measure(this IntPtr hdc, string text, int? length = null,
               Rectangle? rect = null, DrawTextFlags? flags = null)
            {
                if (string.IsNullOrEmpty(text)) return Rectangle.Empty;
                Dimension bounds = rect ?? dummy;
    
                var len = length ?? text.Length;
                var flag = flags.getMeasureFlag(false);
    
                var i = DrawText(hdc, text, len, ref bounds, (int)flag);
    
                return bounds;
            }
    
            static bool Measure(this IntPtr hdc, string text, out Rectangle[] rectangles, Point p,
                int? length = null, Rectangle? rect = null,  DrawTextFlags? flags = null)
            {
                rectangles = new Rectangle[2];
    
                if (string.IsNullOrEmpty(text)) return true;
                Dimension bounds = rect ?? dummy;
    
                var len = length ?? text.Length;
                var flag = flags.getMeasureFlag(false);
    
                Rectangle rc, rc1;
                rc1 = hdc.charBound(text, len, ref bounds, (int)flag, out rc);
                rectangles = new Rectangle[] { rc1, rc };
                return (rectangles[0].Left < bounds.Left || rectangles[0].Has(p.X));
            }
    
            static bool Has(this Rectangle rect, int x = -1,
                int y = -1, int checkRightUpto = -1, int checkBottomUpto = -1)
            {
                if (x == -1 && y == -1)
                {
                    x = 0;
                    y = 0;
                }
                else
                {
                    x = x == -1 ? rect.X : x;
                    y = y == -1 ? rect.Y : y;
                }
                if (checkRightUpto == -1)
                {
                    checkRightUpto = rect.Width;
                }
                if (checkBottomUpto == -1)
                {
                    checkBottomUpto = rect.Height;
                }
                return x >= rect.Left && x <= rect.Left +
                    checkRightUpto && y >= rect.Top &&
                    y <= rect.Top + checkBottomUpto;
            }
    
            static bool Has(this Rectangle rect, Point p,
               int checkRightUpto = -1, int checkBottomUpto = -1)
            {
                return rect.Has(p.X, p.Y, checkRightUpto, checkBottomUpto);
            }
            #endregion
        }
    
        #region structs
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
    
        [StructLayout(LayoutKind.Sequential)]
        public struct Trivertex
        {
            public int x;
            public int y;
            public ushort Red;
            public ushort Green;
            public ushort Blue;
            public ushort Alpha;
    
            public Trivertex(int x, int y, Color color)
                : this(x, y, color.R, color.G, color.B, color.A)
            {
            }
            public Trivertex(int x, int y, Color color, Color other)
                : this(x, y, color.R, color.G, color.B, color.A, other)
            {
            }
            public Trivertex(int x, int y, ushort red, ushort green, ushort blue, ushort alpha)
            {
                this.x = x;
                this.y = y;
                Red = (ushort)(red << 8);
                Green = (ushort)(green << 8);
                Blue = (ushort)(blue << 8);
                Alpha = (ushort)(alpha << 8);
            }
            public Trivertex(int x, int y, ushort red, ushort green, ushort blue, ushort alpha, Color other)
            {
                this.x = x;
                this.y = y;
                Red = (ushort)((red + other.R / 2) << 8);
                Green = (ushort)((green + other.G / 2) << 8);
                Blue = (ushort)((blue + other.B / 2) << 8);
                Alpha = (ushort)((alpha + other.A / 2) << 8);
            }
    
            public static ushort R(Color c)
            {
                return (ushort)(c.R << 8);
            }
            public static ushort G(Color c)
            {
                return (ushort)(c.G << 8);
            }
            public static ushort B(Color c)
            {
                return (ushort)(c.B << 8);
            }
            public static ushort R(Color c, Color c1)
            {
                return (ushort)(((c.R + c1.R / 2)) << 8);
            }
            public static ushort G(Color c, Color c1)
            {
                return (ushort)(((c.G + c1.G / 2)) << 8);
            }
            public static ushort B(Color c, Color c1)
            {
                return (ushort)(((c.B + c1.B / 2)) << 8);
            }
        }
        #endregion
    
        #region textmeasurement interface + class
        public interface ITextMeasurement : ICloneable
        {
            int CharIndex { get; set; }
            int PreviousIndex { get; }
            Rectangle Bounds { get; }
            Rectangle TextBounds { get; }
            char Char { get; }
            Point UserPoint { get; }
    
            void CopyFrom(ITextMeasurement other);
        }
        public class TextMeasurement : ITextMeasurement
        {
            Rectangle now, textBound;
    
            public virtual Rectangle Bounds
            {
                get
                {
                    return now;
                }
                set { now = value; }
            }
            public virtual Rectangle TextBounds
            {
                get
                {
                    return textBound; ;
                }
                set { textBound = value; }
            }
    
            public virtual int CharIndex { get; set; }
            public virtual int PreviousIndex { get; set; }
            public virtual char Char { get; set; }
            public Point UserPoint { get; set; }
    
            public virtual void CopyFrom(ITextMeasurement tm)
            {
                PreviousIndex = tm.PreviousIndex;
                CharIndex = tm.CharIndex;
                Bounds = tm.Bounds;
                Char = tm.Char;
                TextBounds = tm.TextBounds;
                UserPoint = tm.UserPoint;
                if (UserPoint.IsEmpty) UserPoint = Bounds.Location;
            }
            public virtual object Clone()
            {
                var tm = new TextMeasurement();
                tm.CopyFrom(this);
                return tm;
            }
            protected virtual void ResetBounds(Point p)
            {
                ResetBounds(p.X, p.Y);
            }
            protected virtual void ResetBounds(int? lineX = null, int? lineY = null)
            {
                if (lineX.HasValue)
                {
                    now.X = lineX.Value;
                    textBound.X = lineX.Value;
                }
                if (lineY.HasValue)
                {
                    now.Y = lineY.Value;
                    textBound.Y = lineY.Value;
                }
            }
            protected virtual void ResetEmptyBounds(Rectangle rc)
            {
                now = rc;
                textBound = rc;
            }
            public static TextMeasurement Default
            {
                get { return new TextMeasurement(); }
            }
        }
        #endregion
    
        #region enums
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
        public enum Angle
        {
            A0 = 0,
            A45 = 45,
            A90 = 90,
            A135 = 135,
            A180 = 180
        }
        #endregion
    }
 
