    while(true)
    {
       if (globalVariables.InputBox("Name", "Please enter name", ref value) == DialogResult.OK)
        {
            name = value;
            if (name.All(char.IsLetter))
            {
                lblName.Text = value;
                break;
            }
        }
    }
