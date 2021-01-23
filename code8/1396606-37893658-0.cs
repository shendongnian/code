    private void SetWorkerMode(bool running)
    {
        if (running)
        {
            pauseresumeButton.Text = "Pause";
            _busy.Set();
        }
        else
        {
            pauseresumeButton.Text = "Resume";
            _busy.Reset();
        }
    }
