        var mark = Convert.ToSingle(label14.Text);
        if (mark >= 90)
        {
            label15.Text = "A";
        }
        else if (mark >= 80)
        {
            label15.Text = "B";
        }
        else if (mark >= 70)
        {
            label15.Text = "C";
        }
        else if (mark >= 60)
        {
            label15.Text = "D";
        }
        else
            label15.Text = "F";
