    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private bool _drag;
            private SizeF _dragSize;
            private PointF _dragStart;
            private PointF _dragStartOffset;
            private PointF _dragEnd;
            private RectangleF _dragRect;
            private Single _dragRot;
            private Anchor _dragAnchor;
            private RectangleF _rect;
            private PointF _rectPos;
            private Single _rectRot;
            public Form1()
            {
                InitializeComponent();
                _rectPos = new PointF(200, 200);
                _rect = new RectangleF(-40, -30, 80, 60);
                _rectRot = 120;
            }
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                var gc = e.Graphics;
                var mat = new Matrix();
                var rectWidth = _rect.Width;
                var rectHeight = _rect.Height;
                var rectPosX = _rectPos.X;
                var rectPosY = _rectPos.Y;
                mat.Translate(rectPosX, rectPosY);
                mat.Rotate(_rectRot);
                gc.Transform = mat;
                var rect = _rect;
                var rectTopLeft = new RectangleF(_rect.Left - 5f, _rect.Top - 5f, 10f, 10f);
                var rectTopRight = new RectangleF(_rect.Left + rectWidth - 5f, _rect.Top - 5f, 10f, 10f);
                var rectBottomLeft = new RectangleF(_rect.Left - 5f, _rect.Top + rectHeight - 5f, 10f, 10f);
                var rectBottomRight = new RectangleF(_rect.Left + rectWidth - 5f, _rect.Top + rectHeight - 5f, 10f, 10f);
                var rectRotate = new RectangleF(_rect.Left + rectWidth/2f - 5f, _rect.Top - rectHeight/2f - 5f, 10f, 10f);
                var rectCenter = new RectangleF(-10, -10, 10f, 10f);
                var backBrush = new SolidBrush(Color.CadetBlue);
                gc.FillRectangle(backBrush, rect);
                var cornerBrush = new SolidBrush(Color.OrangeRed);
                gc.FillRectangle(cornerBrush, rectTopLeft);
                gc.FillRectangle(cornerBrush, rectTopRight);
                gc.FillRectangle(cornerBrush, rectBottomLeft);
                gc.FillRectangle(cornerBrush, rectBottomRight);
                gc.FillRectangle(cornerBrush, rectRotate);
                gc.FillRectangle(new SolidBrush(Color.Red), rectCenter);
                gc.ResetTransform();
            }
            private void Form1_MouseDown(object sender, MouseEventArgs e)
            {
                var mat = new Matrix();
                var rectWidth = _rect.Width;
                var rectHeight = _rect.Height;
                var rectPosX = _rectPos.X;
                var rectPosY = _rectPos.Y;
                mat.Translate(rectPosX, rectPosY);
                mat.Rotate(_rectRot);
                var rect = _rect;
                var rectTopLeft = new RectangleF(_rect.Left - 5f, _rect.Top - 5f, 10f, 10f);
                var rectTopRight = new RectangleF(_rect.Left + rectWidth - 5f, _rect.Top - 5f, 10f, 10f);
                var rectBottomLeft = new RectangleF(_rect.Left - 5f, _rect.Top + rectHeight - 5f, 10f, 10f);
                var rectBottomRight = new RectangleF(_rect.Left + rectWidth - 5f, _rect.Top + rectHeight - 5f, 10f, 10f);
                var rectRotate = new RectangleF(_rect.Left + rectWidth / 2f - 5f, _rect.Top - rectHeight / 2f - 5f, 10f, 10f);
                mat.Invert();
                var point = mat.TransformPoint(new PointF(e.X, e.Y));
                if (!_drag)
                {
                    if (rectTopLeft.Contains(point))
                    {
                        _drag = true;
                        _dragStart = new PointF(point.X, point.Y);
                        _dragAnchor = WindowsFormsApplication1.Anchor.TopLeft;
                        _dragRect = new RectangleF(_rect.Left, _rect.Top, _rect.Width, _rect.Height);
                    }
                    else if (rectTopRight.Contains(point))
                    {
                        _drag = true;
                        _dragStart = new PointF(point.X, point.Y);
                        _dragAnchor = WindowsFormsApplication1.Anchor.TopRight;
                        _dragRect = new RectangleF(_rect.Left, _rect.Top, _rect.Width, _rect.Height);
                    }
                    else if (rectBottomLeft.Contains(point))
                    {
                        _drag = true;
                        _dragStart = new PointF(point.X, point.Y);
                        _dragAnchor = WindowsFormsApplication1.Anchor.BottomLeft;
                        _dragRect = new RectangleF(_rect.Left, _rect.Top, _rect.Width, _rect.Height);
                    }
                    else if (rectBottomRight.Contains(point))
                    {
                        _drag = true;
                        _dragStart = new PointF(point.X, point.Y);
                        _dragAnchor = WindowsFormsApplication1.Anchor.BottomRight;
                        _dragRect = new RectangleF(_rect.Left, _rect.Top, _rect.Width, _rect.Height);
                    }
                    else if (rectRotate.Contains(point))
                    {
                        _drag = true;
                        _dragStart = new PointF(point.X, point.Y);
                        _dragAnchor = WindowsFormsApplication1.Anchor.Rotation;
                        _dragRect = new RectangleF(_rect.Left, _rect.Top, _rect.Width, _rect.Height);
                        _dragRot = _rectRot;
                    }
                    else if (rect.Contains(point))
                    {
                        _drag = true;
                        _dragStart = new PointF(point.X, point.Y);
                        _dragAnchor = WindowsFormsApplication1.Anchor.Center;
                        _dragRect = new RectangleF(_rect.Left, _rect.Top, _rect.Width, _rect.Height);
                        _dragStartOffset = new PointF(e.X - _rectPos.X, e.Y - _rectPos.Y);
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
                    var mat = new Matrix();
                    mat.Translate(_rectPos.X, _rectPos.Y);
                    mat.Rotate(_rectRot);
                    mat.Invert();
                    var point = mat.TransformPoint(new PointF(e.X, e.Y));
                    _dragEnd = point;
                    var deltaSize = new SizeF(_dragEnd.X - _dragStart.X, _dragEnd.Y - _dragStart.Y);
                    switch (_dragAnchor)
                    {
                        case WindowsFormsApplication1.Anchor.TopLeft:
                            _rect = new RectangleF(
                                _dragRect.Left + deltaSize.Width,
                                _dragRect.Top + deltaSize.Height,
                                _dragRect.Width - deltaSize.Width,
                                _dragRect.Height - deltaSize.Height);
                            break;
                        case WindowsFormsApplication1.Anchor.TopRight:
                            _rect = new RectangleF(
                                _dragRect.Left,
                                _dragRect.Top + deltaSize.Height,
                                _dragRect.Width + deltaSize.Width,
                                _dragRect.Height - deltaSize.Height);
                            break;
                        case WindowsFormsApplication1.Anchor.BottomLeft:
                            _rect = new RectangleF(
                                _dragRect.Left + deltaSize.Width,
                                _dragRect.Top,
                                _dragRect.Width - deltaSize.Width,
                                _dragRect.Height + deltaSize.Height);
                            break;
                        case WindowsFormsApplication1.Anchor.BottomRight:
                            _rect = new RectangleF(
                                _dragRect.Left,
                                _dragRect.Top,
                                _dragRect.Width + deltaSize.Width,
                                _dragRect.Height + deltaSize.Height);
                            break;
                        case WindowsFormsApplication1.Anchor.Rotation:
                            _rectRot = _dragRot;
                            break;
                        case WindowsFormsApplication1.Anchor.Center:
                            _rectPos =  new PointF(e.X - _dragStartOffset.X, e.Y - _dragStartOffset.Y);
                            break;
                    }
                    Invalidate();
                }
            }
        }
    }
