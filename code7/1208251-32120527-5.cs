    public class View : INotifyWhenDisposed
    {
        public View(ViewModel viewModel)
        {
            ViewModel = viewModel;
        }
        public event EventHandler Disposed;
        public ViewModel ViewModel { get; private set; }
        public bool IsDisposed { get; private set; }
        public void Dispose()
        {
            if (!this.IsDisposed)
            {
                this.IsDisposed = true;
                var handler = this.Disposed;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }
    }
    public class ViewModel : IDisposable
    {
        public bool IsDisposed { get; private set; }
        public void Dispose()
        {
            this.IsDisposed = true;
        }
    }
    public class IntegrationTest
    {
        private const string ScopeName = "ViewScope";
        [Fact]
        public void Foo()
        {
            var kernel = new StandardKernel();
            kernel.Bind<View>().ToSelf()
                .DefinesNamedScope(ScopeName);
            kernel.Bind<ViewModel>().ToSelf()
                .InNamedScope(ScopeName);
            var view = kernel.Get<View>();
            view.ViewModel.IsDisposed.Should().BeFalse();
            view.Dispose();
            view.ViewModel.IsDisposed.Should().BeTrue();
        }
    }
