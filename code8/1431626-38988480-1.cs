     public partial class Window2 : Window
        {
    
            class Data
            {
                public string link { get; set; }
                public string content { get; set; }
            }
    
            public Window2()
            {
                InitializeComponent();
                dataGrid1.DataContext = new object[] { new Data { link = "window2?id=3", content = "window2" } };
            }
    
            void EventSetter_OnHandler(object sender, RoutedEventArgs e)
            {
                var rowData = ((Hyperlink)e.OriginalSource).DataContext as Data ;
                // resolve the link ...
            }
    
        }
