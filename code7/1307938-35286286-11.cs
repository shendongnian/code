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
            private RectangleF _dragRect;
            private AnchorPoint _dragAnchor;
            private Single _dragRot;
            private RectangleF _rect;
            private PointF _rectPos;
            private Single _rectRotation;
            public Form1()
            {
                InitializeComponent();
                //Center location of our item
                _rectPos = new PointF(200, 200);
                //The rectangle dimensions in _rectPos space
                _rect = new RectangleF(-40, -30, 80, 60);
                _rectRotation = 0;
            }
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                var gc = e.Graphics;
                // Move Graphics handler to Rectangle's space
                var mat = new Matrix();
                mat.Translate(_rectPos.X, _rectPos.Y);
                mat.Rotate(_rectRotation);
                gc.Transform = mat;
                // All out gizmo rectangles are defined in Rectangle Space
                var rectTopLeft = new RectangleF(_rect.Left - 5f, _rect.Top - 5f, 10f, 10f);
                var rectTopRight = new RectangleF(_rect.Left + _rect.Width - 5f, _rect.Top - 5f, 10f, 10f);
                var rectBottomLeft = new RectangleF(_rect.Left - 5f, _rect.Top + _rect.Height - 5f, 10f, 10f);
                var rectBottomRight = new RectangleF(_rect.Left + _rect.Width - 5f, _rect.Top + _rect.Height - 5f, 10f, 10f);
                var rectRotate = new RectangleF(-5, _rect.Top + -30, 10f, 10f);
                var rectCenter = new RectangleF(-5, -5, 10f, 10f);
                var backBrush = new SolidBrush(Color.CadetBlue);
                var cornerBrush = new SolidBrush(Color.OrangeRed);
                // Looks rotated because we've transformed the graphics context
                gc.FillRectangle(backBrush, _rect);
                gc.FillRectangle(cornerBrush, rectTopLeft);
                gc.FillRectangle(cornerBrush, rectTopRight);
                gc.FillRectangle(cornerBrush, rectBottomLeft);
                gc.FillRectangle(cornerBrush, rectBottomRight);
                gc.FillRectangle(cornerBrush, rectRotate);
                gc.FillRectangle(cornerBrush, rectCenter);
                // Reset Graphics state
                gc.ResetTransform();
            }
            private void Form1_MouseDown(object sender, MouseEventArgs e)
            {
                // Compute a Screen to Rectangle transform 
                var mat = new Matrix();
                mat.Translate(_rectPos.X, _rectPos.Y);
                mat.Rotate(_rectRotation);
                mat.Invert();
                // Mouse point in Rectangle's space. 
                var point = mat.TransformPoint(new PointF(e.X, e.Y));
                var rect = _rect;
                var rectTopLeft = new RectangleF(_rect.Left - 5f, _rect.Top - 5f, 10f, 10f);
                var rectTopRight = new RectangleF(_rect.Left + _rect.Width - 5f, _rect.Top - 5f, 10f, 10f);
                var rectBottomLeft = new RectangleF(_rect.Left - 5f, _rect.Top + _rect.Height - 5f, 10f, 10f);
                var rectBottomRight = new RectangleF(_rect.Left + _rect.Width - 5f, _rect.Top + _rect.Height - 5f, 10f, 10f);
                var rectRotate = new RectangleF(-5, _rect.Top + -30, 10f, 10f);
            
                if (!_drag)
                {
                    //We're in Rectangle space now, so its simple box-point intersection test
                    if (rectTopLeft.Contains(point))
                    {
                        _drag = true;
                        _dragStart = new PointF(point.X, point.Y);
                        _dragAnchor = AnchorPoint.TopLeft;
                        _dragRect = new RectangleF(_rect.Left, _rect.Top, _rect.Width, _rect.Height);
                    }
                    else if (rectTopRight.Contains(point))
                    {
                        _drag = true;
                        _dragStart = new PointF(point.X, point.Y);
                        _dragAnchor = AnchorPoint.TopRight;
                        _dragRect = new RectangleF(_rect.Left, _rect.Top, _rect.Width, _rect.Height);
                    }
                    else if (rectBottomLeft.Contains(point))
                    {
                        _drag = true;
                        _dragStart = new PointF(point.X, point.Y);
                        _dragAnchor = AnchorPoint.BottomLeft;
                        _dragRect = new RectangleF(_rect.Left, _rect.Top, _rect.Width, _rect.Height);
                    }
                    else if (rectBottomRight.Contains(point))
                    {
                        _drag = true;
                        _dragStart = new PointF(point.X, point.Y);
                        _dragAnchor = AnchorPoint.BottomRight;
                        _dragRect = new RectangleF(_rect.Left, _rect.Top, _rect.Width, _rect.Height);
                    }
                    else if (rectRotate.Contains(point))
                    {
                        _drag = true;
                        _dragStart = new PointF(point.X, point.Y);
                        _dragAnchor = AnchorPoint.Rotation;
                        _dragRect = new RectangleF(_rect.Left, _rect.Top, _rect.Width, _rect.Height);
                        _dragRot = _rectRotation;
                    }
                    else if (rect.Contains(point))
                    {
                        _drag = true;
                        _dragStart = new PointF(point.X, point.Y);
                        _dragAnchor = AnchorPoint.Center;
                        _dragRect = new RectangleF(_rect.Left, _rect.Top, _rect.Width, _rect.Height);
                        _dragStartOffset = new PointF(e.X - _rectPos.X, e.Y - _rectPos.Y);
                    }
                }
            }
            private void Form1_MouseUp(object sender, MouseEventArgs e)
            {
                _drag = false;    
            }
            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                if (_drag)
                {
                    var mat = new Matrix();
                    mat.Translate(_rectPos.X, _rectPos.Y);
                    mat.Rotate(_rectRotation);
                    mat.Invert();
                    var point = mat.TransformPoint(new PointF(e.X, e.Y));
                    SizeF deltaSize;
                    PointF clamped;
                    switch (_dragAnchor)
                    {
                        case AnchorPoint.TopLeft:
                            clamped = new PointF(Math.Min(0, point.X), Math.Min(0, point.Y));
                            deltaSize = new SizeF(clamped.X - _dragStart.X, clamped.Y - _dragStart.Y);
                            _rect = new RectangleF(
                                _dragRect.Left + deltaSize.Width,
                                _dragRect.Top + deltaSize.Height,
                                _dragRect.Width - deltaSize.Width,
                                _dragRect.Height - deltaSize.Height);
                            break;
                        case AnchorPoint.TopRight:
                            clamped = new PointF(Math.Max(0, point.X), Math.Min(0, point.Y));
                            deltaSize = new SizeF(clamped.X - _dragStart.X, clamped.Y - _dragStart.Y);
                            _rect = new RectangleF(
                                _dragRect.Left,
                                _dragRect.Top + deltaSize.Height,
                                _dragRect.Width + deltaSize.Width,
                                _dragRect.Height - deltaSize.Height);
                            break;
                        case AnchorPoint.BottomLeft:
                            clamped = new PointF(Math.Min(0, point.X), Math.Max(0, point.Y));
                            deltaSize = new SizeF(clamped.X - _dragStart.X, clamped.Y - _dragStart.Y);
                            _rect = new RectangleF(
                                _dragRect.Left + deltaSize.Width,
                                _dragRect.Top,
                                _dragRect.Width - deltaSize.Width,
                                _dragRect.Height + deltaSize.Height);
                            break;
                        case AnchorPoint.BottomRight:
                            clamped = new PointF(Math.Max(0, point.X), Math.Max(0, point.Y));
                            deltaSize = new SizeF(clamped.X - _dragStart.X, clamped.Y - _dragStart.Y);
                            _rect = new RectangleF(
                                _dragRect.Left,
                                _dragRect.Top,
                                _dragRect.Width + deltaSize.Width,
                                _dragRect.Height + deltaSize.Height);
                            break;
                        case AnchorPoint.Rotation:
                            var vecX = point.X;
                            var vecY = -point.Y;
                            var len = Math.Sqrt(vecX*vecX + vecY*vecY);
                            var normX = vecX / len;
                            var normY = vecY / len;
                            //In rectangles's space, 
                            //compute dot product between, 
                            //Up and mouse-position vector
                            var dotProduct = (0*normX + 1*normY);
                            var angle = Math.Acos(dotProduct);
                            if (point.X < 0)
                                angle = -angle;
                        
                            // Add (delta-radians) to rotation as degrees
                            _rectRotation += (float) ((180/Math.PI)*angle);
                            break;
                        case AnchorPoint.Center:
                            //move this in screen-space
                            _rectPos = new PointF(e.X - _dragStartOffset.X, e.Y - _dragStartOffset.Y);
                            break;
                    }
                    Invalidate();
                }
            }
        }
    }
