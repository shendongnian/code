    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            BindingContext = new Page1ViewModel();
        }
        public ISomethingIWantToHide Foo()
        {
            return new HiddenClass();
        }
    }
    public interface ISomethingIWantToHide
    {
        void Bar(int x);
    }
    internal class HiddenClass : ISomethingIWantToHide
    {
        public void Bar(int x)
        {
            // do something
        }
    }
