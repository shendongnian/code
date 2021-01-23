    public partial class SomeForm: Window
    {
        public SomeClass MyProperty { get; private set; }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.MyProperty = new SomeClass();
            
            //additional setter logic here
            this.Close();
        }
    }
