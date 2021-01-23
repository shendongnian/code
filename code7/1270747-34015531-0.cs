    System::Nullable<System::Boolean> result = window->ShowDialog();
    if (result.HasValue)
    {
        // OK or Cancel
        if (result.Value)
        {
            // OK clicked
        }
        else
        {
            // Cancel clicked
        }
    }
    else
    {
        // dialog closed
    }
