    public class MyButton : Button
    {
        private List<BindingExpression> bindings;
        public List<BindingExpression> Bindings
        {
            get 
            {
                if (bindings == null)
                    bindings = new List<BindingExpression>();
                return bindings; 
            }
            set { bindings = value; }
        }
    }
