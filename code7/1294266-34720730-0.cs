      public class MobileModel 
        {
            private string _brand = string.Empty;
            private List<MobileModelInfo> _model = new List<MobileModelInfo>();
            private string _os = string.Empty;
            public string Brand
            {
                get { return _brand; }
                set {
                    if (value == null) { _brand = String.Empty; }
                    else { _brand = value; } OnPropertyChanged();
                }
            }
        }
