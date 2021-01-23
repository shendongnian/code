    using System;
    using System.Drawing;
    
    using CoreGraphics;
    using Foundation;
    using UIKit;
    
    public class ImageHelper
    {
    	public ImageHelper ()
    	{
    	}
    
    	public static UIImage ImageWithColor(UIColor color, CGRect rect){
    		CGRect rectangleForImage = new CGRect (0, 0, rect.Width, rect.Height);
    		UIGraphics.BeginImageContext (rectangleForImage.Size);
    		CGContext context = UIGraphics.GetCurrentContext ();
    
    		context.SetFillColor (color.CGColor);
    		context.FillRect (rectangleForImage);
    
    		UIImage image = UIGraphics.GetImageFromCurrentImageContext ();
    		UIGraphics.EndImageContext ();
    
    		return image;
    	}
    }
