    if (Result == MessageBoxResult.Yes)
    {
        MessageBox.Show("You Reserved this seat");
        btnSeat1.Text = "Reserved";
    }
    else if (Result == MessageBoxResult.No)
    {
        Environment.Exit(0);
    }
