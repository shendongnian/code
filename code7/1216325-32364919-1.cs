    // Dynamically set the properties of the control
    btn.Location = new Point((lbl.Width + cmb.Width + 17), 5);
    btn.Size = new System.Drawing.Size(90, 23);
    btn.Text = "Add to Table";
    
    // Create the control
    this.Controls.Add(btn);
    // Link it to an Event
    btn.Click += new EventHandler(btn_Click);
