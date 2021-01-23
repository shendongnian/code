    public abstract class ViewModel : INotifyPropertyChanged
    {
        private ViewModel parentViewModel;
        public ViewModel(ViewModel parent)
        {
            parentViewModel = parent;
        }
        /// <summary>
        /// Get the top ViewModel for binding (eg Root.IsEnabled)
        /// </summary>
        public ViewModel Root
        {
            get
            {
                if (parentViewModel != null)
                {
                    return parentViewModel.Root;
                }
                else
                {
                    return this;
                }
            }
        }
    }
