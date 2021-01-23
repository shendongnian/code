    public class FoobarUser
    {
        private readonly WidgetFactory.Create factory;
        public FoobarUser(WidgetFactory.Create factory)
        {
            this.factory = factory;
        }
        public void Method()
        {
            var widget = this.factory(3, 4.836);
            // Do something with my widget
            // Possibly add it to a widget collection
        }
    }
