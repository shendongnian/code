    public string GetOutput()
    {
        const string buildOutputPaneGuid = "{1BD8A850-02D1-11D1-BEE7-00A0C913D1F8}";
        const string vsWindowKindOutput = "{34E76E81-EE4A-11D0-AE2E-00A0C90FFFC3}";
        var outputWindow = dte.Windows.Item(/*EnvDTE.Constants.*/vsWindowKindOutput);
        var outputWindowDynamic = outputWindow.Object;
        foreach(OutputWindowPane pane in outputWindowDynamic.OutputWindowPanes)
        {
            if (pane.Guid == buildOutputPaneGuid)
            {
                try
                {
                    pane.Activate();
                    var sel = pane.TextDocument.Selection;
                    sel.StartOfDocument(false);
                    sel.EndOfDocument(true);
                    return sel.Text;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        return null;
    }
