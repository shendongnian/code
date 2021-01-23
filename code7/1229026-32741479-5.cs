    private void DragScope_GiveFeedback(object sender, GiveFeedbackEventArgs e)
    {
        if (_adorner == null) return;
        if (e.Effects == DragDropEffects.Copy)
        {
            _adorner.Opacity = 1d;
            e.Handled = true;
        }
        else
        {
            _adorner.Opacity = 0.5d;
            e.Handled = true;
        }
    }
