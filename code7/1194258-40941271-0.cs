      public class CircleGraph : UIView
      {
          const float FULL_CIRCLE = 2 * (float)Math.PI;
          int _radius = 10;
          int _lineWidth = 10;
          nfloat _percentComplete = 0.0f;
          UIColor _backColor = UIColor.LightGray; //UIColor.FromRGB(46, 60, 76);
          UIColor _frontColor = UIColor.Green; //UIColor.FromRGB(234, 105, 92);
    
          public CircleGraph(CGRect frame, int lineWidth, nfloat percentComplete)
          {
             _lineWidth = lineWidth;
             _percentComplete = percentComplete;
             this.Frame = new CGRect(frame.X, frame.Y, frame.Width, frame.Height);
             this.BackgroundColor = UIColor.Clear;
    
          }
    
          public CircleGraph(CGRect frame, int lineWidth, nfloat percentComplete, UIColor backColor, UIColor frontColor)
          {
             _lineWidth = lineWidth;
             _percentComplete = percentComplete;
             this.Frame = new CGRect(frame.X, frame.Y, frame.Width, frame.Height);
             this.BackgroundColor = UIColor.Clear;
             _backColor = backColor;
             _frontColor = frontColor;
          }
    
          public override void Draw(CoreGraphics.CGRect rect)
          {
             base.Draw(rect);
    
             using (CGContext g = UIGraphics.GetCurrentContext())
             {
                _radius = (int)((this.Bounds.Width) / 3) - 8;
                DrawGraph(g, this.Bounds.GetMidX(), this.Bounds.GetMidY());
             };
          }
    
          public void DrawGraph(CGContext g, nfloat x, nfloat y)
          {
             g.SetLineWidth(_lineWidth);
    
             // Draw background circle
             CGPath path = new CGPath();
             _backColor.SetStroke();
             path.AddArc(x, y, _radius, 0, _percentComplete * FULL_CIRCLE, true);
             g.AddPath(path);
             g.DrawPath(CGPathDrawingMode.Stroke);
    
             // Draw overlay circle
             var pathStatus = new CGPath();
             _frontColor.SetStroke();
    
             // Same Arc params except direction so colors don't overlap
             pathStatus.AddArc(x, y, _radius, 0, _percentComplete * FULL_CIRCLE, false);
             g.AddPath(pathStatus);
             g.DrawPath(CGPathDrawingMode.Stroke);
          }
       }
