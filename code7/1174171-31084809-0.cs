    int idx;
    string[] userDefinedText;
    Fixed fix;
    public MainWindow () : base (Gtk.WindowType.Toplevel) {
        Build ();
        // I'm not really sure how you store the text or just a list of widgets 
        // but for the sake of simplicity I'm just using a string array
        idx = 0;
        userDefinedText = new string[3] { "Medium text length", "Long text that goes on and on", "Short" };
        fix = new Fixed ();
        fix.SetSizeRequest (400, 400);
        Add (fix);
        fix.Show ();
        Button b = new Button ();
        b.SetSizeRequest (-1, -1);
        b.Label = userDefinedText [idx];
        b.ExposeEvent += OnButtonExposeEvent;
        fix.Put (b, 5, 5);
        b.Show ();
        ShowAll ();
    }
    protected void OnButtonExposeEvent (object sender, ExposeEventArgs args) {
        if (idx < (userDefinedText.Length - 1)) {
            // There are still widgets to be placed on the screen
            ++idx;
            Button b = sender as Button;
            int x = b.Allocation.Right;
            int y = b.Allocation.Bottom;
            Button b2 = new Button ();
            b2.SetSizeRequest (-1, -1);
            b2.Label = userDefinedText [idx];
            b2.ExposeEvent += OnButtonExposeEvent;
            fix.Put (b2, x + 5, y + 5);
            b2.Show ();
        }
    }
