    private void ResizeForm()
    {
        this.SuspendLayout(); // Suspends the layout logic until ResumeLayout() is called (below)
        if (itemPanel.Controls.Count < 1) return;
        var lastElement = itemPanel.Controls[itemPanel.Controls.Count - 1];
        // The Form is the correct size, no need to resize it:
        if (lastElement.Bottom + lastElement.Margin.Bottom == itemPanel.Height) return;
        Height = 38 + lastElement.Bottom + lastElement.Margin.Bottom;
        this.ResumeLayout(); // ADD THIS AS WELL
    }
