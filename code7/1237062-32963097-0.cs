    private void Render()
    {
        Dispatcher.Invoke((Action)(() =>
        {
            element.InvalidateVisual();
        }));
    }
