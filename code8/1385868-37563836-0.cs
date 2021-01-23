    protected override void OnPreviewKeyDown(KeyEventArgs e)
    {
        // Let ComboBox's original method handle it
        base.OnPreviewKeyDown(e);
        // Manually check if the ComboBox handled an "Enter" key
        // If yes, set e.Handled back to false so that Command binding can consume the same event
        Key key = e.Key;
        if (key == Key.Enter)
            e.Handled = false;
    }
