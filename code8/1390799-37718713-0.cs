    private Form GetParentForm(Control parent)
    {
        Form Result = parent as Form;
        if (Result == null)
        {
            if (parent != null)
            {
                // Recursive is cool
                return GetParentForm(parent.Parent);
            }
        }
        return Result;
    }
