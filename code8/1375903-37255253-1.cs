    foreach (var pair in buttonLabelPairs)
    {
        if (string.IsNullOrEmpty(pair.AssociatedLabel.Text))
        {
            pair.AssociatedButton.Visible = false;
        }
    }
