    public class P1 : P
    {
        public P1(BindingSource bs):base()
        {
            base.bindingSource1.DataSource = bs.DataSource;
        }
    }
