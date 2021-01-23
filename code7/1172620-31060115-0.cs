    using System;
    using System.Drawing;
    
    using Foundation;
    using UIKit;
    using MediaPlayer;
    using CoreGraphics;
    
    namespace CHANGE_THIS_TO_YOUR_NAME_SPACE
    {
    	public partial class VideoViewController : UIViewController
    	{
    		MPMoviePlayerController moviePlayer;
    		UILabel label;
    		UITextView textView;
    
    		public VideoViewController () : base ("VideoViewController", null)
    		{
    		}
    
    		public override void DidReceiveMemoryWarning ()
    		{
    			// Releases the view if it doesn't have a superview.
    			base.DidReceiveMemoryWarning ();
    
    			// Release any cached data, images, etc that aren't in use.
    		}
    
    		public override void ViewDidLoad ()
    		{
    			base.ViewDidLoad ();
    
    			// Perform any additional setup after loading the view, typically from a nib.
    			moviePlayer = new MPMoviePlayerController (NSUrl.FromString ("http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4")); // Use FromString() to play video directly from web.
    			moviePlayer.View.Frame = new CGRect (0, 20, View.Frame.Size.Width, 180); // size of the video frame
    			moviePlayer.ScalingMode = MPMovieScalingMode.AspectFit; // show the video relative to the video size dimensions
    			moviePlayer.PrepareToPlay ();
    			moviePlayer.Play ();
    			View.Add (moviePlayer.View); // add the view after video starts playing to display it
    
    			// UILabel
    			label = new UILabel (new CGRect(0,200, View.Frame.Size.Width, 50));
    			label.Text = "Tutorial";
    			label.Font.WithSize (36);
    			View.Add (label.ViewForBaselineLayout);
    
    			// UITextView
    			textView = new UITextView ();
    			textView.Editable = false;
    			textView.ScrollEnabled = true;
    			textView.UserInteractionEnabled = true;
    			textView.ViewForBaselineLayout.Frame = new CGRect (0, 250, View.Frame.Size.Width, View.Frame.Size.Height * 3);
    			textView.Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. [shorten text for this post] "; // shorten text for this post
    			View.Add (textView);
    
    		}
    	}
    }
