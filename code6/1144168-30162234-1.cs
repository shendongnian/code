    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Right:
                if (tbControl.SelectedIndex == 0)
                    tbControl.SelectedIndex = 1;
                break;
            case Key.Left:
                if (tbControl.SelectedIndex == 1)
                    tbControl.SelectedIndex = 0;
                break;
        }
    }
