    public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
        {
          if (segue.Identifier == "TaskSegue") { // set in Storyboard
            var navctlr = segue.DestinationViewController as TaskDetailViewController;
            if (navctlr != null) {
              // some public method you create in your destination controller
              navctlr.SetTask (this, item); 
            }
          }
        }
