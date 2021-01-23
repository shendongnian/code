    private string versichertennummer = "";
        public string Versichertennummer
        {
            get { return versichertennummer; }
            set 
            {
                if (VersichertennummerAlt.Length > 0)
                {
                    MessageBox.Show("Es kann nur die neue ODER die alte Versichertennummer     eingegeben werden.\n Eine von beiden löschen.");
                    //OnPropertyChanged("Versichertennummer");
                    return;
                }
                else
                {
                    versichertennummer = value;
                }
            }
        }
        private string versichertennummerAlt = "";
        public string VersichertennummerAlt
        {
            get { return versichertennummerAlt; }
            set
                {
                    if (Versichertennummer.Length > 0)
                    {
                        //versichertennummerAlt = "";
                        //OnPropertyChanged("VersichertennummerAlt");
                        MessageBox.Show("Es kann nur die neue ODER die alte Versichertennummer eingegeben werden.\n Eine von beiden löschen.");
                        return;
                    }
                    else
                    {
                        versichertennummerAlt = value;
                    }
                }
        }
