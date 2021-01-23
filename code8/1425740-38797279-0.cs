    foreach (list listControl in panel1.Controls.Cast<Control>.OfType<list>())
    {
        if (list != this)
        {
            list.Deselect();
        }
    }
