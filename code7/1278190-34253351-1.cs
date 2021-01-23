    class ListPage : ContentPage
    {
        public ListPage(String categoryName)
        {
             var getItems = parseAPI.myInfo (Application.Current.Properties [categoryName].ToString ());
