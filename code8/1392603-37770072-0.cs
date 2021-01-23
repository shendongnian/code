     public void fillradioButton()
    {
        for (int i = 0; i < officeLists.Count; i++)
        {
            RadioButton rbutton = new RadioButton()
            {
                Name = "rbutton",
                Text = candidate_surname + " " + candidate_name,
                Left = _RadiobuttonPos.X,
                Top = _RadiobuttonPos.Y,
            };
    
            rbutton.CheckedChanged += RadioButtonCheckedChanged;
            this.Controls.Add(rbutton);
            _RadiobuttonPos.Y += 25;
        }
    }
    
