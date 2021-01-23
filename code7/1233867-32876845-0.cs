    private void StripEmptyFromCopy()
    {
        string[] separated = Clipboard.GetText().Split('\n').Where(s => !String.IsNullOrWhiteSpace(s)).ToArray();
        string copy = String.Join("\n", separated);
        if (!String.IsNullOrEmpty(copy))
        {
            Clipboard.SetText(copy);
        }
    }
