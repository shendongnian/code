    public class LinkViewToViewModel
    {
        public LinkViewToViewModel(ContentControl view, ObservableObject viewModel)
        {
            View = view;
            ViewModel = viewModel;
        }
        public ContentControl View { get; set; }
        public ObservableObject ViewModel { get; set; }
    }
