    public class MyClass : DependencyObject
    {
        public MyClass()
        {
            this.Button = new Button();
            Button.Width = 500;
            Button.Height = 400;
            Button.Content = "Bound to Window Height";
        }
        private Binding height;
        public Binding Height
        {
            get { return height; }
            set 
            {
                height = value;
                ApplyBinding();
            }
        }
        public Button Button { get; set; }
        private void ApplyBinding()
        {
            this.Button.SetBinding(Button.HeightProperty, this.Height);
        }
       
    }
