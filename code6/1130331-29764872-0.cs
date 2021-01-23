    public String ButtonNotification {
       get { return yourUserControlLabel.Text; }
       set {
             if (value == null || value == "") { yourUserControlLabel.Visibility = Hidden; }
             else { yourUserControlLabel.Visibility = Visible; }
             yourUserControlLabel.Text = value;
       }
    }
