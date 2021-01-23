    public void Application_WindowSelectionChange(PowerPoint.Selection sel)
    {
        if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
        {
            if (sel.ShapeRange.Name == "MyTextBox")
            {
             //Perform certain action.
            }
        }
    }
