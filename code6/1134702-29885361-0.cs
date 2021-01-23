    private static void ChangeDescriptionHeight(PropertyGrid grid, int height)
    {
        if (grid == null) throw new ArgumentNullException("grid");
        foreach (Control control in grid.Controls)
        {
            if (control.GetType().Name == "DocComment")
            {
                var fieldInfo = control.GetType().BaseType.GetField("userSized",
                                                                    BindingFlags.Instance |
                                                                    BindingFlags.NonPublic);
                fieldInfo.SetValue(control, true);
                control.Height = height;
                return;
            }
        }
    }
