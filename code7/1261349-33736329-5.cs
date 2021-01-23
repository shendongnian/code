    public delegate void MyEventHandler(Gates gate, CustomEvent e);
    public class Gates
    {
        public event MyEventHandler OnStatusChanged;
        bool A, B, X;
        public Gates()
        {
            A = true;
            B = true;
            X = false;
        }
        public bool InputA
        {
            get { return A; }
            set
            {
                A = value;
                X = (A & !B | B & !A);
                if(OnStatusChanged!=null)
                    OnStatusChanged(this, new CustomEvent(X));
            }
        }
        public bool InputB
        {
            get { return B; }
            set
            {
                B = value;
                X = (A & !B | B & !A);
                if (OnStatusChanged != null) 
                    OnStatusChanged(this, new CustomEvent(X));
            }
        }
        public bool OutputX
        {
            get { return X; }
            set { X = value; }
        }
    }
