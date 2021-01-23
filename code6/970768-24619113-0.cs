    public class MyView
    {
        public MyView(MyViewModel viewModel)
        {
            this.DataContext = viewModel;
            viewModel.Close += (_, __) => Dispatcher.Invoke(this.Close);
        }
    }
