    private void OnMouseMove(object sender, MouseEventArgs e)
    {
        var tb=(TextBlock)e.OriginalSource;
        var lastMove = e.GetPosition((IInputElement)e.OriginalSource);
        Debug.WriteLine(tb.Text + ":" + lastMove);
    }
