    private void CreateButton()
    {
        var button = new Button
        {
            Text = "Press me",
            Name = "SomeButtonName",
            Location = new Point(10,10),
            Size    = new Size(100,20),
            Visible =  true,
        };
    
        button.Click += (s, e) => this.ButtonClicked();
    
        this.Controls.Add(button);
    }
    
    private void ButtonClicked()
    {
        // this will fire on click
    }
