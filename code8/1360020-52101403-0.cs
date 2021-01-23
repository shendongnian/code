    public partial class MyMasterDetailPage: MasterDetailPage
        {
            private Stack navigationStack = new Stack();
            public MyMasterDetailPage()
            {
                InitializeComponent();
                navigationStack.Push(Detail);
                try
                {
                    masterPage.listView.ItemSelected += OnItemSelected;
                  
                }
                catch (Exception exc)
                {
    
                    System.Diagnostics.Debug.WriteLine(exc.Message);
                }
    
            }
