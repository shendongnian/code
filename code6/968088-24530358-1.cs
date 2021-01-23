    public sealed class TearOffWindowWrapper : IWindowWrapper<TearOffWindow>
        {
            private readonly TearOffWindow _window;
            
            public TearOffWindowWrapper(ITearOffViewModel viewModel)
            {
                _window = new TearOffWindow { DataContext = viewModel };
            }
    
            public event EventHandler Closed;
            
            public bool IsVisible
            {
                get
                {
                    return _window.Visibility == Visibility.Visible;
                }
    
                set
                {
                    _window.Visibility = value ? Visibility.Visible : Visibility.Hidden;
                }
            }
          
            public void Close()
            {
                _window.Close();
            }
            
            public void Show()
            {
                if (!_window.IsVisible)
                {
                    _window.Closed += WindowOnClosed;
    
                    _window.Show();
                    _window.Activate();
                }
            }
    
            public void Activate()
            {
                if (_window.IsVisible)
                {
                    _window.Activate();
                }
            }
    
            private void WindowOnClosed(object sender, EventArgs eventArgs)
            {
                _window.Closed -= WindowOnClosed;
    
                var closed = Closed;
                if (closed != null)
                {
                    closed(this, EventArgs.Empty);
                }
            }
        }
