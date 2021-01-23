    foreach (list listControl in Parent.Controls.Cast<Control>().OfType<list>())
    {
        if (list != this)
        {
            list.Deselect();
        }
    }
