    public class SelectMultipleBasePage<T> : ContentPage
    {
        public delegate void ImageSelectedHandler(object sender, EventArgs e);
        public event ImageSelectedHandler OnImageSelected;
        public class WrappedItemSelectionTemplate : ViewCell
        {
            private readonly ImageSelectedHandler _parentHandler;
            public WrappedItemSelectionTemplate(ImageSelectedHandler parentHandler)
                : base()
            {
                _parentHandler = parentHandler;
                // ...
            }
            private void OnImageBtnTapped(object sender, EventArgs e)
            {
                //...
                _parentHandler.Invoke(sender, e);
            }
        }
        public static List<WrappedSelection<T>> WrappedItems = new List<WrappedSelection<T>>();
        public SelectMultipleBasePage(List<T> items)
        {
            WrappedItems = items.Select(item => new WrappedSelection<T>() { Item = item, IsSelected = false }).ToList();
            ListView mainList = new ListView()
            {
                ItemsSource = WrappedItems,
                ItemTemplate = new DataTemplate(() => new WrappedItemSelectionTemplate(HandleImageSelected)),
            };
			// ...
        }
		
		private void HandleImageSelected(object sender, EventArgs e)
        {
            if (OnImageSelected != null)
            {
                OnImageSelected(sender, e);
            }
        }
    }
