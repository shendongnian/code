    class ListPage : ContentPage
    {
        public ListPage()
        {
            getItems ();
        }
        private string categoryName; 
        public string TheCategoryName 
        { 
            get { return categoryName; }
            set { categoryName= value; }
        }
