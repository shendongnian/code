    // read values from comboboxes
    var verticalCount = (int)ComboBox1.SelectedValue;
    var horizontalValue = (int)ComboBox2.SelectedValue;
    
    // create m*n textboxes
    for(var i = 0; i < verticalCount; i++)
    {
        for(var j = 0; j < horizontalValue; j++)
        {
            var newTextBox = new TextBox()
            {
                Name = string.Format("TextBox_{0}_{1}", i, j); // put the name here
            }
            var x = //calculate x location for textbox
            var y = //calculate y location for textbox
            newTextBox.Location = new Point(x, y);
    
            // add new created textbox to parent control (form)
            this.Controls.Add(newTextBox)
        }
    }
