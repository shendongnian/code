    private void DisplayView(Form view)
    {
        if (view == null || view == _mainView) return;
        view.TopLevel = false;
        _mainView.GameArea.Controls.Clear();
        _mainView.GameArea.Controls.Add(view);
        view.Dock = DockStyle.Fill;
        view.BringToFront();
        view.Show();
        _mainView.GameArea.Controls[0].Focus();
    }
