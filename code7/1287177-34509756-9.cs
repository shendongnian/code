    class Indicator<T> where T : Control
    {
        private T _control;
        private Indicator() 
        {
        }
        public Indicator(T control)
        {
           if(control.GetType().GetProperties().All(p => p.Name != "Image" || p.PropertyType != typeof(Image)))
           { 
              throw new ArgumentException("This type of control is not supported");
           }
           this._control = control;
        }
    }
