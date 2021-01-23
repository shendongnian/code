    namespace HowToMeasurePortionOfText
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
    
            [DllImport("user32.dll")]
            static extern int DrawText(IntPtr hdc, string lpStr, int nCount, ref Dimension lpRect, int wFormat);
    
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(this IntPtr hdc, IntPtr hObject);
    
            [DllImport("gdi32.dll")]
            public static extern int DeleteObject(this IntPtr hObject);
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
            public static Rectangle RangeBound(this IDeviceContext dc, Font font, string text,
               Rectangle container, int start, int end, DrawTextFlags? flags = null)
            {
                Rectangle textBound, uptoIndex;
                return dc.RangeBound(font, text, container, start, end, out textBound, out uptoIndex, flags);
            }
    
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
                textBound =hdc.textBound(text, container, flags);
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
    }
