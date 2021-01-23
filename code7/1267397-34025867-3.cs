    public class SalerySubject : ISalerySubject
    {
        public event EventHandler OnNotify;
        private int salery;
        public int Salery
        {
            get { return salery; }
            set
            {
                salery = value;
                if (OnNotify != null) OnNotify(this, new EventArgs());
            }
        }
    }
