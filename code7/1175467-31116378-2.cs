        MainWindow.Topmost = true;
        MainWindow.Show();
        MainWindow.Activate();
        MainWindow.Topmost = false;
        MainWindow.Focus();
    }
    /// <summary>
    /// Raises the <see cref="E:System.Windows.Window.Closing"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"/> that contains the event data.</param>
    protected override void OnClosing(CancelEventArgs e)
    {
        base.OnClosing(e);
    }
