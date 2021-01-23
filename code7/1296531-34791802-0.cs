        foreach (NumericSpinnerControl spinner in FindVisualChildren<NumericSpinnerControl>(this))
        {
            // do something here
            spinner.MouseLeave = OnMouseLeave;
            spinner.PreviewMouseUp = OnPreviewMouseUp;
            spinner.PreviewMouseMove = OnPreviewMouseMove;
        }
