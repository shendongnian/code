    // Your form instance to hide/show
    Form hidingForm = null;
    
    void Main()
    {
        Form f = new Form();
        Button b1 = new Button();
        Button b2 = new Button();
        b1.Click += onClickB1;
        b2.Click += onClickB2;
        
        b1.Location = new System.Drawing.Point(0,0);
        b2.Location = new System.Drawing.Point(0, 30);
        b1.Text = "Hide";
        b2.Text = "Show";
    
        f.Controls.AddRange(new Control[] {b1, b2});
        f.ShowDialog();
    }
    
    void onClickB1(object sender, EventArgs e)
    {
        // Hide the global instance if it exists and it is visible
        if(hidingForm != null && hidingForm.Visible)
            hidingForm.Hide();
    }
    void onClickB2(object sender, EventArgs e)
    {
        // Create and show the global instance if it doesn't exist
        if (hidingForm == null)
        {
            hidingForm = new Form();
            hidingForm.Show();
            // Get informed here if the user closes the form
            hidingForm.FormClosed += onClosed;
        }
        else
        {
            // Show the form if it is not visible
            if(!hidingForm.Visible)
                hidingForm.Show();
        }
    }
    void onClosed(object sender, FormClosedEventArgs e)
    {
        // Uh-oh.... the user has closed the form, don't get fooled...
        hidingForm = null;
    }
