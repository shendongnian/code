     public override void ViewDidLoad ()
            {
                base.ViewDidLoad ();
                // Perform any additional setup after loading the view, typically from a nib.
                var button = new UIButton (UIButtonType.RoundedRect) {
                    Frame = UIScreen.MainScreen.Bounds,
                    BackgroundColor = UIColor.Red
                };
    
                button.TouchUpInside += (sender, e) => {
                    var item = NSObject.FromObject ("HI");
                    var activityItems = new NSObject[] { item };
                    UIActivity[] applicationActivities = null;
    
                    var activityController = new UIActivityViewController (activityItems, applicationActivities);
    
                    PresentViewController (activityController, true, null);
                };
    
                Add (button);
            }
