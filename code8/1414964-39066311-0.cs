    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Permissions;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    using System.Drawing.Drawing2D;
    using System.Reflection;
    [ComVisible(true)]
    [DefaultEvent("SplitterMoved")]
    [DefaultProperty("Dock")]
    [Designer(typeof(MySplitterDesigner))]
    public class MySplitter : Control
    {
        private Point anchor = Point.Empty;
        private System.Windows.Forms.BorderStyle borderStyle;
        private const int defaultWidth = 3;
        private const int DRAW_END = 3;
        private const int DRAW_MOVE = 2;
        private const int DRAW_START = 1;
        private static readonly object EVENT_MOVED = new object();
        private static readonly object EVENT_MOVING = new object();
        private int initTargetSize;
        private int lastDrawSplit = -1;
        private int maxSize;
        private int minExtra = 25;
        private int minSize = 25;
        private int splitSize = -1;
        private Control splitTarget;
        private SplitterMessageFilter splitterMessageFilter;
        private int splitterThickness = 3;
        [Category("Behavior")]
        [Description("Occurs when the splitter is done being moved.")]
        public event SplitterEventHandler SplitterMoved
        {
            add
            {
                base.Events.AddHandler(EVENT_MOVED, value);
            }
            remove
            {
                base.Events.RemoveHandler(EVENT_MOVED, value);
            }
        }
        [Category("Behavior")]
        [Description("Occurs when the splitter is being moved.")]
        public event SplitterEventHandler SplitterMoving
        {
            add
            {
                base.Events.AddHandler(EVENT_MOVING, value);
            }
            remove
            {
                base.Events.RemoveHandler(EVENT_MOVING, value);
            }
        }
        private class HighLight : Form
        {
            public HighLight()
            {
                FormBorderStyle = FormBorderStyle.None;
                BackColor = Color.Black;
                Opacity = 0;
                ShowInTaskbar = false;
                StartPosition = FormStartPosition.Manual;
            }
            protected override void OnDeactivate(EventArgs e)
            {
                base.OnDeactivate(e);
                this.Hide();
            }
            private const int SW_SHOWNOACTIVATE = 4;
            private const int HWND_TOPMOST = -1;
            private const uint SWP_NOACTIVATE = 0x0010;
    
            [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
            static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    
            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    
            public static void ShowInactiveTopmost(Form frm)
            {
                ShowWindow(frm.Handle, SW_SHOWNOACTIVATE);
                SetWindowPos(frm.Handle.ToInt32(), HWND_TOPMOST,
                frm.Left, frm.Top, frm.Width, frm.Height,
                SWP_NOACTIVATE);
                frm.Opacity = 0.3;
            }
        }
        HighLight highlight;
        public MySplitter()
        {
            base.SetStyle(ControlStyles.Selectable, false);
            this.TabStop = false;
            this.minSize = 0x19;
            this.minExtra = 0x19;
            this.Dock = DockStyle.Left;
            highlight = new HighLight();
        }
        private void ApplySplitPosition()
        {
            this.SplitPosition = this.splitSize;
        }
        private SplitData CalcSplitBounds()
        {
            SplitData data = new SplitData();
            Control control = this.FindTarget();
            data.target = control;
            if (control != null)
            {
                switch (control.Dock)
                {
                    case DockStyle.Top:
                    case DockStyle.Bottom:
                        this.initTargetSize = control.Bounds.Height;
                        break;
    
                    case DockStyle.Left:
                    case DockStyle.Right:
                        this.initTargetSize = control.Bounds.Width;
                        break;
                }
                Control parentInternal = this.Parent;
                Control.ControlCollection controls = parentInternal.Controls;
                int count = controls.Count;
                int num2 = 0;
                int num3 = 0;
                for (int i = 0; i < count; i++)
                {
                    Control control3 = controls[i];
                    if (control3 != control)
                    {
                        switch (control3.Dock)
                        {
                            case DockStyle.Top:
                            case DockStyle.Bottom:
                                num3 += control3.Height;
                                break;
    
                            case DockStyle.Left:
                            case DockStyle.Right:
                                num2 += control3.Width;
                                break;
                        }
                    }
                }
                Size clientSize = parentInternal.ClientSize;
                if (this.Horizontal)
                {
                    this.maxSize = (clientSize.Width - num2) - this.minExtra;
                }
                else
                {
                    this.maxSize = (clientSize.Height - num3) - this.minExtra;
                }
                data.dockWidth = num2;
                data.dockHeight = num3;
            }
            return data;
        }
        private Rectangle CalcSplitLine(int splitSize, int minWeight)
        {
            Rectangle bounds = base.Bounds;
            Rectangle rectangle2 = this.splitTarget.Bounds;
            switch (this.Dock)
            {
                case DockStyle.Top:
                    if (bounds.Height < minWeight)
                    {
                        bounds.Height = minWeight;
                    }
                    bounds.Y = rectangle2.Y + splitSize;
                    return bounds;
    
                case DockStyle.Bottom:
                    if (bounds.Height < minWeight)
                    {
                        bounds.Height = minWeight;
                    }
                    bounds.Y = ((rectangle2.Y + rectangle2.Height) - splitSize) - bounds.Height;
                    return bounds;
    
                case DockStyle.Left:
                    if (bounds.Width < minWeight)
                    {
                        bounds.Width = minWeight;
                    }
                    bounds.X = rectangle2.X + splitSize;
                    return bounds;
    
                case DockStyle.Right:
                    if (bounds.Width < minWeight)
                    {
                        bounds.Width = minWeight;
                    }
                    bounds.X = ((rectangle2.X + rectangle2.Width) - splitSize) - bounds.Width;
                    return bounds;
            }
            return bounds;
        }
        private int CalcSplitSize()
        {
            Control control = this.FindTarget();
            if (control != null)
            {
                Rectangle bounds = control.Bounds;
                switch (this.Dock)
                {
                    case DockStyle.Top:
                    case DockStyle.Bottom:
                        return bounds.Height;
    
                    case DockStyle.Left:
                    case DockStyle.Right:
                        return bounds.Width;
                }
            }
            return -1;
        }
        private void DrawSplitBar(int mode)
        {
            if ((mode != 1) && (this.lastDrawSplit != -1))
            {
                this.DrawSplitHelper(this.lastDrawSplit);
                this.lastDrawSplit = -1;
            }
            else if ((mode != 1) && (this.lastDrawSplit == -1))
            {
                return;
            }
            if (mode != 3)
            {
                this.DrawSplitHelper(this.splitSize);
                this.lastDrawSplit = this.splitSize;
            }
            else
            {
                if (this.lastDrawSplit != -1)
                {
                    this.DrawSplitHelper(this.lastDrawSplit);
                }
                this.lastDrawSplit = -1;
                highlight.Hide();
            }
            Console.WriteLine(mode);
        }
        private void DrawSplitHelper(int splitSize)
        {
            if (this.splitTarget != null)
            {
                Rectangle rectangle = this.CalcSplitLine(splitSize, 3);
                var r = this.Parent.RectangleToScreen(rectangle);
                if (!highlight.Visible)
                    HighLight.ShowInactiveTopmost(highlight);
                highlight.Location = r.Location;
                highlight.Size = r.Size;
            }
        }
        private Control FindTarget()
        {
            Control parentInternal = this.Parent;
            if (parentInternal != null)
            {
                Control.ControlCollection controls = parentInternal.Controls;
                int count = controls.Count;
                DockStyle dock = this.Dock;
                for (int i = 0; i < count; i++)
                {
                    Control control2 = controls[i];
                    if (control2 != this)
                    {
                        switch (dock)
                        {
                            case DockStyle.Top:
                                if (control2.Bottom != base.Top)
                                {
                                    break;
                                }
                                return control2;
    
                            case DockStyle.Bottom:
                                if (control2.Top != base.Bottom)
                                {
                                    break;
                                }
                                return control2;
    
                            case DockStyle.Left:
                                if (control2.Right != base.Left)
                                {
                                    break;
                                }
                                return control2;
    
                            case DockStyle.Right:
                                if (control2.Left != base.Right)
                                {
                                    break;
                                }
                                return control2;
                        }
                    }
                }
            }
            return null;
        }
        private int GetSplitSize(int x, int y)
        {
            int num;
            if (this.Horizontal)
                num = x - this.anchor.X;
            else
                num = y - this.anchor.Y;
            int num2 = 0;
            switch (this.Dock)
            {
                case DockStyle.Top:
                    num2 = this.splitTarget.Height + num;
                    break;
                case DockStyle.Bottom:
                    num2 = this.splitTarget.Height - num;
                    break;
                case DockStyle.Left:
                    num2 = this.splitTarget.Width + num;
                    break;
                case DockStyle.Right:
                    num2 = this.splitTarget.Width - num;
                    break;
            }
            return Math.Max(Math.Min(num2, this.maxSize), this.minSize);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if ((this.splitTarget != null) && (e.KeyCode == Keys.Escape))
                this.SplitEnd(false);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((e.Button == MouseButtons.Left) && (e.Clicks == 1))
                this.SplitBegin(e.X, e.Y);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this.splitTarget != null)
            {
                int x = e.X + base.Left;
                int y = e.Y + base.Top;
                Rectangle rectangle = this.CalcSplitLine(this.GetSplitSize(e.X, e.Y), 0);
                int splitX = rectangle.X;
                int splitY = rectangle.Y;
                this.OnSplitterMoving(new SplitterEventArgs(x, y, splitX, splitY));
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (this.splitTarget != null)
            {
                Rectangle rectangle = this.CalcSplitLine(this.GetSplitSize(e.X, e.Y), 0);
                this.SplitEnd(true);
            }
        }
        protected virtual void OnSplitterMoved(SplitterEventArgs sevent)
        {
            SplitterEventHandler handler = (SplitterEventHandler)base.Events[EVENT_MOVED];
            if (handler != null)
                handler(this, sevent);
            if (this.splitTarget != null)
                this.SplitMove(sevent.SplitX, sevent.SplitY);
        }
        protected virtual void OnSplitterMoving(SplitterEventArgs sevent)
        {
            SplitterEventHandler handler = (SplitterEventHandler)base.Events[EVENT_MOVING];
            if (handler != null)
                handler(this, sevent);
            if (this.splitTarget != null)
                this.SplitMove(sevent.SplitX, sevent.SplitY);
        }
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (this.Horizontal)
            {
                if (width < 1)
                    width = 3;
                this.splitterThickness = width;
            }
            else
            {
                if (height < 1)
                    height = 3;
                this.splitterThickness = height;
            }
            base.SetBoundsCore(x, y, width, height, specified);
        }
        private void SplitBegin(int x, int y)
        {
            SplitData data = this.CalcSplitBounds();
            if ((data.target != null) && (this.minSize < this.maxSize))
            {
                this.anchor = new Point(x, y);
                this.splitTarget = data.target;
                this.splitSize = this.GetSplitSize(x, y);
                try
                {
                    if (this.splitterMessageFilter != null)
                        this.splitterMessageFilter = new SplitterMessageFilter(this);
                    Application.AddMessageFilter(this.splitterMessageFilter);
                }
                finally { }
                this.Capture = true;
                this.DrawSplitBar(1);
            }
        }
        private void SplitEnd(bool accept)
        {
            this.DrawSplitBar(3);
            this.splitTarget = null;
            this.Capture = false;
            if (this.splitterMessageFilter != null)
            {
                Application.RemoveMessageFilter(this.splitterMessageFilter);
                this.splitterMessageFilter = null;
            }
            if (accept)
                this.ApplySplitPosition();
            else if (this.splitSize != this.initTargetSize)
                this.SplitPosition = this.initTargetSize;
            this.anchor = Point.Empty;
        }
        private void SplitMove(int x, int y)
        {
            int splitSize = this.GetSplitSize((x - base.Left) + this.anchor.X, (y - base.Top) + this.anchor.Y);
            if (this.splitSize != splitSize)
            {
                this.splitSize = splitSize;
                this.DrawSplitBar(2);
            }
        }
        public override string ToString()
        {
            string str = base.ToString();
            string[] textArray1 = new string[] { str, ", MinExtra: ", this.MinExtra.ToString(CultureInfo.CurrentCulture), ", MinSize: ", this.MinSize.ToString(CultureInfo.CurrentCulture) };
            return string.Concat(textArray1);
        }
        [DefaultValue(0)]
        [Category("Appearance")]
        [Description("The border type of the control.")]
        public System.Windows.Forms.BorderStyle BorderStyle
        {
            get
            {
                return this.borderStyle;
            }
            set
            {
                if (!IsEnumValid(value, (int)value, 0, 2))
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(System.Windows.Forms.BorderStyle));
                if (this.borderStyle != value)
                {
                    this.borderStyle = value;
                    base.UpdateStyles();
                }
            }
        }
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams createParams = base.CreateParams;
                createParams.ExStyle &= -513;
                createParams.Style &= -8388609;
                System.Windows.Forms.BorderStyle borderStyle = this.borderStyle;
                if (borderStyle != System.Windows.Forms.BorderStyle.FixedSingle)
                {
                    if (borderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
                    {
                        createParams.ExStyle |= 0x200;
                    }
                    return createParams;
                }
                createParams.Style |= 0x800000;
                return createParams;
            }
        }
        protected override Cursor DefaultCursor
        {
            get
            {
                switch (this.Dock)
                {
                    case DockStyle.Top:
                    case DockStyle.Bottom:
                        return Cursors.HSplit;
                    case DockStyle.Left:
                    case DockStyle.Right:
                        return Cursors.VSplit;
                }
                return base.DefaultCursor;
            }
        }
        protected override System.Windows.Forms.ImeMode DefaultImeMode
        {
            get
            {
                return System.Windows.Forms.ImeMode.Disable;
            }
        }
        protected override Size DefaultSize
        {
            get { return new Size(3, 3); }
        }
        [Localizable(true), DefaultValue(3)]
        public override DockStyle Dock
        {
            get { return base.Dock; }
            set
            {
                if (((value != DockStyle.Top) && (value != DockStyle.Bottom)) && ((value != DockStyle.Left) && (value != DockStyle.Right)))
                    throw new ArgumentException("Splitter control must be docked left, right, top, or bottom.");
                int splitterThickness = this.splitterThickness;
                base.Dock = value;
                switch (this.Dock)
                {
                    case DockStyle.Top:
                    case DockStyle.Bottom:
                        if (this.splitterThickness == -1)
                            break;
                        base.Height = splitterThickness;
                        return;
                    case DockStyle.Left:
                    case DockStyle.Right:
                        if (this.splitterThickness != -1)
                            base.Width = splitterThickness;
                        break;
                    default:
                        return;
                }
            }
        }
        private bool Horizontal
        {
            get
            {
                DockStyle dock = this.Dock;
                if (dock != DockStyle.Left)
                    return (dock == DockStyle.Right);
                return true;
            }
        }
        [Category("Behavior")]
        [Localizable(true)]
        [DefaultValue(25)]
        [Description("Specifies the minimum size of the undocked area.")]
        public int MinExtra
        {
            get { return this.minExtra; }
            set
            {
                if (value < 0)
                    value = 0;
                this.minExtra = value;
            }
        }
        [Category("Behavior")]
        [Localizable(true)]
        [DefaultValue(25)]
        [Description("Specifies the minimum size of the control being resized.")]
        public int MinSize
        {
            get { return this.minSize; }
            set
            {
                if (value < 0)
                    value = 0;
                this.minSize = value;
            }
        }
        [Category("Layout")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The current position of the splitter, or -1 if it is not bound to a control.")]
        public int SplitPosition
        {
            get
            {
                if (this.splitSize == -1)
                {
                    this.splitSize = this.CalcSplitSize();
                }
                return this.splitSize;
            }
            set
            {
                SplitData data = this.CalcSplitBounds();
                if (value > this.maxSize)
                {
                    value = this.maxSize;
                }
                if (value < this.minSize)
                {
                    value = this.minSize;
                }
                this.splitSize = value;
                this.DrawSplitBar(3);
                if (data.target == null)
                {
                    this.splitSize = -1;
                }
                else
                {
                    Rectangle bounds = data.target.Bounds;
                    switch (this.Dock)
                    {
                        case DockStyle.Top:
                            bounds.Height = value;
                            break;
    
                        case DockStyle.Bottom:
                            bounds.Y += bounds.Height - this.splitSize;
                            bounds.Height = value;
                            break;
    
                        case DockStyle.Left:
                            bounds.Width = value;
                            break;
    
                        case DockStyle.Right:
                            bounds.X += bounds.Width - this.splitSize;
                            bounds.Width = value;
                            break;
                    }
                    data.target.Bounds = bounds;
                    Application.DoEvents();
                    this.OnSplitterMoved(new SplitterEventArgs(base.Left, base.Top, base.Left + (bounds.Width / 2), base.Top + (bounds.Height / 2)));
                }
            }
        }
        private class SplitData
        {
            public int dockHeight = -1;
            public int dockWidth = -1;
            internal Control target;
        }
        private class SplitterMessageFilter : IMessageFilter
        {
            private MySplitter owner;
            public SplitterMessageFilter(MySplitter splitter)
            {
                this.owner = splitter;
            }
            public bool PreFilterMessage(ref Message m)
            {
                if ((m.Msg < 0x100) || (m.Msg > 0x108))
                {
                    return false;
                }
                if ((m.Msg == 0x100) && (((int)((long)m.WParam)) == 0x1b))
                {
                    this.owner.SplitEnd(false);
                }
                return true;
            }
        }
        private static bool IsEnumValid(Enum enumValue, int value, int minValue, int maxValue)
        {
            return ((value >= minValue) && (value <= maxValue));
        }
    }
    
    public class MySplitterDesigner : ControlDesigner
    {
        public MySplitterDesigner() { base.AutoResizeHandles = true; }
        private void DrawBorder(Graphics graphics)
        {
            Color white;
            Control control = this.Control;
            Rectangle clientRectangle = control.ClientRectangle;
            if (control.BackColor.GetBrightness() < 0.5)
                white = Color.White;
            else
                white = Color.Black;
            using (Pen pen = new Pen(white))
            {
                pen.DashStyle = DashStyle.Dash;
                clientRectangle.Width--;
                clientRectangle.Height--;
                graphics.DrawRectangle(pen, clientRectangle);
            }
        }
        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            base.OnPaintAdornments(pe);
            if (((MySplitter)base.Component).BorderStyle == BorderStyle.None)
                this.DrawBorder(pe.Graphics);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x47)
                this.Control.Invalidate();
            base.WndProc(ref m);
        }
    }
