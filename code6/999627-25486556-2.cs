    if (shape.Parent.InvokeRequired)
    {
        shape.Parent.Invoke((System.Action)(() =>
        {
            button.BackColor = Color.Red;
        }));
    }
    else
    {
       button.BackColor = Color.Red;
    }
