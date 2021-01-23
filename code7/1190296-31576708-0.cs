    public partial class MainWindow : Window
    {
        public Widget GetFocusedElement()
        {
            Console.WriteLine (((Widget)this.Focus).Name);
            return this.Focus;
        }
    }
