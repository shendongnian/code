        public static event EventHandler ListCOMChanged;
        private static List<string> p_ListCOM;
        public static List<string> ListCOM
        {
            get { return p_ListCOM; }
            set 
            {
                p_ListCOM = value;
                if (ListCOMChanged != null)
                    ListCOMChanged(null, EventArgs.Empty);
            }
        }
