        public class INT
        {
            private int _i;
            public INT()      { _i = 0; }
            public INT(int i) { _i = i; }
            // Used to access the _i member.
            public int self
            {
                get {return _i;}
                set {_i = value;}
            }
            // Used to display what is stored inside.
            public override string ToString()
            {
                return _i + "";
            }
        }
