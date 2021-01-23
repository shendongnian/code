    public class NoteViewController : UIViewController
    {
        Note note;
        
        public NoteViewController (Note _note)
        {
            note = _note;
        }
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            this.NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB (255, 0, 255); // Repeated code. Also used in MainViewController.cs
            
            this.Title = note == null ? "Add Note" : "Edit Note";
            this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes () { ForegroundColor = UIColor.White };
            this.NavigationController.NavigationBar.TintColor = UIColor.White;
            this.View.BackgroundColor = UIColor.White;
            var titleEntryBox = new UITextField () {
                Frame = new CoreGraphics.CGRect (0, 100, View.Bounds.Width, 45), // Repeated code
                BackgroundColor = UIColor.LightGray,
                TextColor = UIColor.Black,
                Text = note == null ? string.Empty : note.title
            };
            var descriptionLabel = new UILabel () {
                Frame = new CoreGraphics.CGRect (10, 180, 250, 35),
                Text = "Description",
            };
            var descriptionEntryBox = new UITextView () {
                Frame = new CoreGraphics.CGRect (0, 220, View.Bounds.Width, 100), // Repeated code
                BackgroundColor = UIColor.LightGray,
                TextColor = UIColor.Black,
                Text = note == null ? string.Empty : note.description
            };
            var button = new UIButton () {
                Frame = new CoreGraphics.CGRect (10, 340, 120, 45)  
            }; // Repeated code
            if (note == null) {
              button.SetTitle ("Add", UIControlState.Normal);
            } else {
              button.SetTitle ("Update", UIControlState.Normal);
            }
           
            button.BackgroundColor = UIColor.FromRGB (255, 0, 255);
            button.SetTitleColor (UIColor.White, UIControlState.Normal);
            this.View.Add (titleEntryBox);
            this.View.Add (descriptionLabel);
            this.View.Add (descriptionEntryBox);
            this.View.Add (button); 
            button.TouchUpInside += (sender, e) => {
                if (note == null) {
                var noteToSave = new Note () {
                    title = titleEntryBox.Text,
                    description = descriptionEntryBox.Text,
                    dateCreated = DateTime.Now
                };
                Database.InsertNote (noteToSave);
                titleEntryBox.Text = "";
                descriptionEntryBox.Text = "";
                } else {
                if (titleEntryBox.Text.Length < 4)
                    return;
                var noteToUpdate = new Note () {
                    ID = note.ID,
                    title = titleEntryBox.Text,
                    description = descriptionEntryBox.Text,
                    dateCreated = DateTime.Now
                };
                Database.updateNote (noteToUpdate);
                this.NavigationController.PopViewController (true);
                }
                
            };
        }
    }
