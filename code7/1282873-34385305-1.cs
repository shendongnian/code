    class EditProcessor : IEditProcessor
    {
        private readonly Container container;
    
        public EditProcessor(Container container)
        {
            this.container = container;
        }
    
        public void EditItem<T>(T item)
        {
            var viewModel = typeof (IViewModel<>).MakeGenericType(typeof (T));
            dynamic instance = container.GetInstance(viewModel);
    
            instance.EditItem((dynamic) item);
        }
    }
