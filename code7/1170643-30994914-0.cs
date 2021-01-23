    public static class UINavigationBarExtensions
    	{
    		public static void RemoveShadowImage(this UINavigationBar navigationBar)
    		{
    			foreach (var image in 
    				from subView in navigationBar.Subviews
    				select subView as UIImageView
    				into imageView
    				where imageView != null && imageView.ToString()
    					.Contains("BarBackground")
    				from image in imageView.Subviews.OfType<UIImageView>()
    					.Where(image => Math.Abs(image.Bounds.Height - 0.5) < float.Epsilon)
    				select image)
    				image.RemoveFromSuperview();
    		}
    	}
