    public partial class Form1 : Form
    {
        private bool _drag;
        private SizeF _dragSize;
        private PointF _dragStart;
        private PointF _dragEnd;
        private RectangleF _dragRect;
        private RectangleF _rect;
        private PointF _rectPos;
        private Single _rectRot;
        private Corner _dragCorner;
        public Form1()
        {
            InitializeComponent();
            _rectPos = new PointF(100, 100);
            _rect = new RectangleF(-40, -30, 80, 60);
            _rectRot = 20;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var gc = e.Graphics;
            var mat = new Matrix();
            var rectWidth = _rect.Width;
            var rectHeight = _rect.Height;
            var rectPosX = _rectPos.X + _rect.Left;
            var rectPosY = _rectPos.Y + _rect.Top;
            mat.Translate(_rectPos.X, _rectPos.Y);
            mat.Rotate(_rectRot);
            gc.Transform = mat;
            var rect = new RectangleF(rectPosX, rectPosY, rectWidth, rectHeight);
            var rectTopLeft = new RectangleF(rectPosX - 5f, rectPosY - 5f, 10f, 10f);
            var rectTopRight = new RectangleF(rectPosX + rectWidth - 5f, rectPosY - 5f, 10f, 10f);
            var rectBottomLeft = new RectangleF(rectPosX - 5f, rectPosY + rectHeight - 5f, 10f, 10f);
            var rectBottomRight = new RectangleF(rectPosX + rectWidth - 5f, rectPosY + rectHeight - 5f, 10f, 10f);
            var backBrush = new SolidBrush(Color.CadetBlue);
            gc.FillRectangle(backBrush, rect);
            var cornerBrush = new SolidBrush(Color.OrangeRed);
            gc.FillRectangle(cornerBrush, rectTopLeft);
            gc.FillRectangle(cornerBrush, rectTopRight);
            gc.FillRectangle(cornerBrush, rectBottomLeft);
            gc.FillRectangle(cornerBrush, rectBottomRight);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            var rectWidth = _rect.Width;
            var rectHeight = _rect.Height;
            var rectPosX = _rectPos.X + _rect.Left;
            var rectPosY = _rectPos.Y + _rect.Top;
            var mat = new Matrix();
            mat.Translate(_rectPos.X, _rectPos.Y);
            mat.Rotate(_rectRot);
            mat.Invert();
            var point = mat.TransformPoint(new PointF(e.X, e.Y));
            var rect = new RectangleF(rectPosX, rectPosY, rectWidth, rectHeight);
            var rectTopLeft = new RectangleF(rectPosX - 5f, rectPosY - 5f, 10f, 10f);
            var rectTopRight = new RectangleF(rectPosX + rectWidth - 5f, rectPosY - 5f, 10f, 10f);
            var rectBottomLeft = new RectangleF(rectPosX - 5f, rectPosY + rectHeight - 5f, 10f, 10f);
            var rectBottomRight = new RectangleF(rectPosX + rectWidth - 5f, rectPosY + rectHeight - 5f, 10f, 10f);
            if (!_drag)
            {
                if (rectTopLeft.Contains(point))
                {
                    _drag = true;
                    _dragStart = new PointF(point.X, point.Y);
                    _dragCorner = Corner.TopLeft;
                    _dragRect = new RectangleF(_rect.Left, _rect.Top, _rect.Width, _rect.Height);
                }
                else if (rectTopRight.Contains(point))
                {
                    _drag = true;
                    _dragStart = new PointF(point.X, point.Y);
                    _dragCorner = Corner.TopRight;
                    _dragRect = new RectangleF(_rect.Left, _rect.Top, _rect.Width, _rect.Height);
                }
                else if (rectBottomLeft.Contains(point))
                {
                    _drag = true;
                    _dragStart = new PointF(point.X, point.Y);
                    _dragCorner = Corner.BottomLeft;
                    _dragRect = new RectangleF(_rect.Left, _rect.Top, _rect.Width, _rect.Height);
                }
                else if (rectBottomRight.Contains(point))
                {
                    _drag = true;
                    _dragStart = new PointF(point.X, point.Y);
                    _dragCorner = Corner.BottomRight;
                    _dragRect = new RectangleF(_rect.Left, _rect.Top, _rect.Width, _rect.Height);
                }
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_drag)
            {
                _drag = false;
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_drag)
            {
                var rectWidth = _rect.Width;
                var rectHeight = _rect.Height;
                var rectPosX = _rectPos.X + _rect.Left;
                var rectPosY = _rectPos.Y + _rect.Top;
                var mat = new Matrix();
                mat.Translate(_rectPos.X, _rectPos.Y);
                mat.Rotate(_rectRot);
                mat.Invert();
                var point = mat.TransformPoint(new PointF(e.X, e.Y));
                _dragEnd = point;
                var deltaSize = new SizeF(_dragEnd.X - _dragStart.X, _dragEnd.Y - _dragStart.Y);
                
                switch (_dragCorner)
                {
                    case Corner.TopLeft:
                        _rect = new RectangleF(
                            _dragRect.Left + deltaSize.Width,
                            _dragRect.Top + deltaSize.Height,
                            _dragRect.Width - deltaSize.Width,
                            _dragRect.Height - deltaSize.Height);
                        break;
                    case Corner.TopRight:
                        _rect = new RectangleF(
                            _dragRect.Left ,
                            _dragRect.Top + deltaSize.Height,
                            _dragRect.Width + deltaSize.Width,
                            _dragRect.Height - deltaSize.Height);
                        break;
                    case Corner.BottomLeft:
                        _rect = new RectangleF(
                            _dragRect.Left + deltaSize.Width,
                            _dragRect.Top ,
                            _dragRect.Width - deltaSize.Width,
                            _dragRect.Height + deltaSize.Height);
                        break;
                    case Corner.BottomRight:
                        _rect = new RectangleF(
                            _dragRect.Left,
                            _dragRect.Top ,
                            _dragRect.Width + deltaSize.Width,
                            _dragRect.Height + deltaSize.Height);
                        break;
                }
                Invalidate();
            }
        }
    }
