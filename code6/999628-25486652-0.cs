    var action = (System.Action)(() =>
    {
        shape.BackColor = Color.Red;
    };
    if (shape.Parent.InvokeRequired)
    {
        shape.Parent.Invoke(action);
    }
    else
    {
       action();
    }
