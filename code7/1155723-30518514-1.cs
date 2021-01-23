    public void ReadAllErrors()
    {
        StringBuilder sb = new StringBuilder();
        foreach (string propertyName in errors.Keys)
        {
            sb.AppendLine(propertyName + "\t");
            foreach (string error in errors[propertyName])
            {
                sb.AppendLine(error.ToString() + "\n");
            }
        }
        MessageBox.Show(sb.ToString());
    }
