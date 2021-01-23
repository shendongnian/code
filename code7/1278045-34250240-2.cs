    public class Logger : TextWriter
    {
        private readonly ViewModel _viewModel;
        public Logger(ViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Write(char value)
        {
            base.Write(value);
            _viewModel.LogBox += value;
        }
        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
