    [ContentProperty( "Content" )]
    public class MyUserControl: UserControl
    {
        public new Object Content
        {
            get => base.Content;
            set => base.Content = value;
        }
        ...
    }
