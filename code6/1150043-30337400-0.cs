    public static class ViewModel
    {
        public static ViewModel<T> Create<T>(T viewData, PageData pageData) 
        {
            return new ViewModel<T>(viewData, pageData);
        }
    }
