    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    ~MainWindow()
    {
        Dispose();
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing) 
        {
            if (viewModel != null)
            {
                viewModel.RequestClose -= CloseWindow;
                viewModel.Dispose();
                viewModel = null;
            }
        }
    }
