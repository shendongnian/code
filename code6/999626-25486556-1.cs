    if (shape.Parent.InvokeRequired)
    {
        this.Invoke((System.Action)(() =>
        {
            button.BackColor = Color.Red;
        }));
    }
    else
    {
       button.BackColor = Color.Red;
    }
