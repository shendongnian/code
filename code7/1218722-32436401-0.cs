      string _placeHolderText = "Some Test Placeholder...";
      public override void ViewWillAppear (bool animated)
      {
         base.ViewWillAppear (animated);
         var textView1 = new UITextField (new CGRect (0, 0, UIScreen.MainScreen.Bounds.Width, 100)) {
            Placeholder = _placeHolderText,
            BorderStyle = UITextBorderStyle.Line
         };
         textView1.EditingDidBegin += (object sender, EventArgs e) =>
         {
            textView1.Placeholder = string.Empty;
         };
         textView1.EditingDidEnd += (object sender, EventArgs e) =>
         {
            textView1.Placeholder = _placeHolderText;
         };
         var textView2 = new UITextField (new CGRect (0, textView1.Frame.Bottom, UIScreen.MainScreen.Bounds.Width, 100)) {
            Placeholder = _placeHolderText,
            BorderStyle = UITextBorderStyle.Line
         };
         this.View.AddSubviews (textView1, textView2);
      }
