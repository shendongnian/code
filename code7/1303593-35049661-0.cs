    public UITableView TableLayoutHelper (UIViewController controller)
            {
    
                UITableView tableLayout = new UITableView (controller) { // Error appears here
                    Frame = new CoreGraphics.CGRect (0, this.NavigationController.NavigationBar.Frame.Bottom,
                        controller.View.Bounds.Width,
                        controller.View.Bounds.Height - controller.NavigationController.NavigationBar.Frame.Height),
                };
                return tableLayout;
            }
this.NavigationController.NavigationBar.Frame.Bottom
