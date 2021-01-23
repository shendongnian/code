        foreach (var ctrl in grpA.Controls)
        {
            if (ctrl.GetType() == typeof(Label))
            {
                Label lbl = ctrl as Label;
                Label b = new Label();
                // copy required properties
                b.Text = lbl.Text
                b.TextAlign = lbl.TextAlign;
                // ... other properties
                grpB.Controls.Add(b);
            }
        }
