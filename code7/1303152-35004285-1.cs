     public override void ViewDidLoad ()
    
            {
                base.ViewDidLoad ();
                 If(uiHelper == null)
                 {
                     uiHelper = new UIHelper(); 
                 }
                //this.NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB (255,0,255);
                this.NavigationController.NavigationBar.BarTintColor = uiHelper.SetNavBarRGB(); // Exception being thrown here
                this.Title = "Notes";
                this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes () { ForegroundColor = UIColor.White };
    
                table = new UITableView () {
                    Frame = new CoreGraphics.CGRect (0, this.NavigationController.NavigationBar.Frame.Bottom, this.View.Bounds.Width, this.View.Bounds.Height - this.NavigationController.NavigationBar.Frame.Height),
                };
                this.View.Add (table);
    
                var addButton = new UIBarButtonItem (UIBarButtonSystemItem.Add);
                addButton.TintColor = UIColor.White;
    
                this.NavigationItem.RightBarButtonItems = new UIBarButtonItem[] { addButton };
                addButton.Clicked += (sender, e) => {
                    this.NavigationController.PushViewController (new NoteViewController(), true);
                };
    
                notes = Database.getNotes ();
                table.Source = new NotesTableViewSource (notes, this);
            }
