    if (e.ColumnIndex == yourColumnIndex && String.IsNullOrEmpty((string)e.FormattedValue))
    {
        e.PaintBackground(e.ClipBounds, true);
        e.Handled = true;
    }
}` 
