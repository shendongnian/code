    TabControl itemsTab = (TabControl)FindName("tabControl");
    TextEditor currentTextEditor = itemsTab.GetChildOfType<TextEditor>();
    if (currentTextEditor != null)
    {
        File.WriteAllText(saveF.FileName, currentTextEditor.Text);
    }
