    private static string[] OpenFileSelector(string description, string extension1)
    {
        if (string.IsNullOrEmpty(description))
        {
            throw new ArgumentException("description must be a non-empty string");
        }
        OpenFileDialog op = new OpenFileDialog();
        op.InitialDirectory = @"C:\";
        op.Title = "Seleccione los archivos";
        op.Filter = description + "|*." + extension1;
        op.Multiselect = true;
    
        bool? res = op.ShowDialog();
    
        if (res != null && res.Value) return op.FileNames;
        return null;
    }
