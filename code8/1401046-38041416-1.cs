    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            BindingContext = new Page1ViewModel();
        }
        public IWantToHideSomething Foo()
        {
            return new HiddenClass();
        }
    }
    public interface IWantToHideSomething
    {
        void Bar(int x);
    }
    internal class HiddenClass : IWantToHideSomething
    {
        public void Bar(int x)
        {
            // do something
        }
    }
