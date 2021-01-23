    for (int i = 1; i <= 10; i++)
    {
        var checkbox = new CheckBox();
        checkbox.Name = String.Format("checkbox{0}", i);
        //Set the location.  Notice the y-offset grows 20px with each i
        checkbox.Location = new Point(50, 150 + (i*20)); 
        checkbox.Text = "1";
        checkbox.Checked = false;
        //Assign them all the same event handler
        checkbox.CheckedChanged += new EventHandler(checkbox_CheckedChanged); 
        //other checkbox considerations like checkbox.BringToFront()
        //very important, you must add the checkbox the the form's controls 
        this.Controls.Add(checkbox); 
    }
