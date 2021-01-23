    using System;
    using MapKit;
    using UIKit;
    
    namespace mkmapview
    {
    	public class MyAnnotationView : MKAnnotationView // or MKPointAnnotation
    	{
    		UIFont _font;
    		public MyAnnotationView (IMKAnnotation annotation, string reuseIdentifier, UIFont font) : base (annotation, reuseIdentifier)
    		{
    			_font = font;
    			CanShowCallout = true;
    			Image = UIImage.FromFile ("Images/MapPin.png");
    		}
    
    		void searchViewHierarchy (UIView currentView)
    		{
    			// short-circuit
    			if (currentView.Subviews == null || currentView.Subviews.Length == 0) {
    				return;
    			}
    			foreach (UIView subView in currentView.Subviews) {
    				if (subView is UILabel) {
    					(subView as UILabel).Font = _font;
    				} else {
    					searchViewHierarchy (subView);
    				}
    			}
    		}
    
    		public override void LayoutSubviews ()
    		{
    			if (!Selected)
    				return;
    			base.LayoutSubviews ();
    			foreach (UIView view in Subviews) {
    				Console.WriteLine (view);
    				searchViewHierarchy (view);
    			}
    		}
    	}
    }
