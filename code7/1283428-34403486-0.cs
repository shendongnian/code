    class Variables
    {
        public int iSelectedIndex = -1;
        
        public SupplyParameter _page;
        public Variables(SupplyParameter page)
        {
             _page = page;
        }
        private void SupplyParameterReady()
        {
            if (tbSupply1 && tbSupply2 && unitSupply1 && unitSupply2)
            {
                _page.ParameterCompleted(true);
            }
            else
            {
                _page.ParameterCompleted(false);
            }
        }
        public bool tbSupply1
        {
            get
            {
                return tbSupply1;
            }
            set
            {
                tbSupply1 = value;
                if (value)
                    SupplyParameterReady();
            }
        }
    }
    public sealed partial class SupplyParameter : Page
    {
        Variables _vars;
        public SupplyParameter()
        {
            vars = new Variables(this);
        }
        ...
        public void ParameterCompleted(bool ready)
        {
            btnSupplyCalculationGo.IsEnabled = ready;
        }
    }
