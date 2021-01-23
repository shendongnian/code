    private void AssignEvent(Control.ControlCollection controls)
    {   
        foreach (Control c in controls)
        {
            if (c is Textbox)
                c.MouseUp += OnMouseUp;
            if (c.HasChildren)
                AssignEvent(c.Controls);
        }
    }
