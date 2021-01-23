    public partial class MyControl
    {
        public MyControl()
        {
           Loaded += async (s, e) => await ((MyViewModel)DataContext).InitializeAsync();
        }
    }
