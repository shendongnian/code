    foreach(Control ctrl in panel1.Controls)
    {
        // Check if control is of type label
        if(ctrl.GetType() == typeof(Label))
        {
            // check the name of the label
            if(ctrl.Name == "label1")
            {
                // do what ever you want
                MessageBox.Show("Label 1 existing");
            }
        }
    }
