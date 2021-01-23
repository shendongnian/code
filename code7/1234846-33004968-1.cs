    public DelegateCommand<object> SizeUpdateCommand { get; set; }
        private void Execute(object size)
        {
            var newSize = (Size)size;
        }
        private bool CanExecute(object size)
        {
            return true;
        }
