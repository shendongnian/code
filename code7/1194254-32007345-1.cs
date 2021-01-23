    using System;
        using UIKit;
        using CoreGraphics;
        
        namespace CircleTest.Touch
        {
        	public class CircleGraph : UIView
        	{
        		int _radius = 10;
        		int _lineWidth = 10;
        		nfloat _degrees = 0.0f;
        		UIColor _backColor = UIColor.FromRGB(46, 60, 76);
        		UIColor _frontColor = UIColor.FromRGB(234, 105, 92);
        		//FromRGB (234, 105, 92);
    
    		public CircleGrap (CGRect frame, int lineWidth, nfloat degrees)
    		{
    			_lineWidth = lineWidth;
    			_degrees = degrees;
    			this.Frame = new CGRect(frame.X, frame.Y, frame.Width, frame.Height);
    			this.BackgroundColor = UIColor.C lear;
    
    		}
    
    		public CircleGraph (CGRect frame, int lineWidth, UIColor backColor, UIColor frontColor)
    		{
    			_lineWidth = lineWidth;
    			this.Frame = new CGRect(frame.X, frame.Y, frame.Width, frame.Height);
    			this.BackgroundColor = UIColor.Clear;
    		
    		}
    
    		public override void Draw (CoreGraphics.CGRect rect)
    		{
    			base.Draw (rect);
    
    			using (CGContext g = UIGraphics.GetCurrentContext ()) {
    				_radius = (int)( (this.Frame.Width) / 3) - 8;
    				DrawGraph(g, this.Frame.GetMidX(), this.Frame.GetMidY());
    			};
    		}
    
    		public void DrawGraph(CGContext g,nfloat x0,nfloat y0) {
    			g.SetLineWidth (_lineWidth);
    
    			// Draw background circle
    			CGPath path = new CGPath ();
    			_backColor.SetStroke ();
    			path.AddArc (x0, y0, _radius, 0, 2.0f * (float)Math.PI, true);
    			g.AddPath (path);
    			g.DrawPath (CGPathDrawingMode.Stroke);
    
    			// Draw overlay circle
    			var pathStatus = new CGPath ();
    			_frontColor.SetStroke ();
    			pathStatus.AddArc(x0, y0, _radius, 0, _degrees * (float)Math.PI, false);
    			g.AddPath (pathStatus);
    			g.DrawPath (CGPathDrawingMode.Stroke);
    		}
    	}
    }
