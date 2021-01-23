    private void ClearTable_Click(object sender, RoutedEventArgs e)
    {
        // Try to cast the sender to a Control
        Control ctrl = sender as Control;
        if (ctrl != null)
        {
            // Get the control name
            string name = ctrl.Name;
        }
    }
