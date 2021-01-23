    public override void ViewDidLoad ()
    {
    base.ViewDidLoad ();
 
    // Your stuff
 
    NSNotificationCenter.DefaultCenter.AddObserver   ("UIKeyboardWillShowNotification", KeyboardWillShow);
    }
 
     public void KeyboardWillShow(NSNotification notification)
     {
     var doneButton = new UIButton (UIButtonType.Custom);
     doneButton.Frame = new RectangleF (0, 163, 106, 53);
     doneButton.SetTitle ("DONE", UIControlState.Normal);
     doneButton.SetTitleColor (UIColor.Black, UIControlState.Normal);
     doneButton.SetTitleColor (UIColor.White, UIControlState.Highlighted);
 
     doneButton.TouchUpInside += (sender, e) => 
     {
     // Make the Done button do its thing!  The textfield shouldn't be the   first responder
     _txtNumbers.ResignFirstResponder();
     };
 
     // This is the 'magic' that could change with future version of iOS
     var keyboard = _txtNumbers.WeakInputDelegate as UIView;
     if (keyboard != null)
     {
         keyboard.AddSubview (doneButton);
     }
    }
