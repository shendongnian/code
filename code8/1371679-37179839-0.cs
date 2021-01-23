    private void ChangeTabs(DTE vs, int newTabSize, int newIndentSize)
    {
        var cSharp = vs.Properties["TextEditor", "CSharp"];
        EnvDTE.Property lTabSize = cSharp.Item("TabSize");
        EnvDTE.Property lIndentSize = cSharp.Item("IndentSize");
        lTabSize.Value = newTabSize;
        lIndentSize.Value = newIndentSize;
    }
    private void ChangeSettings()
    {
       DTE vs = (DTE)GetService(typeof(DTE)); 
       ChangeTabs(vs, 3, 3);
    }
