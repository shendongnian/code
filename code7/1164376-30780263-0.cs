    public class BoolParameter
    {
    
        private static string _ParameterName = String.Empty;
        private static bool _CurrentVal = false;
    
        public BoolParameter(string ParameterName)
        {
            _ParameterName = ParameterName;
        }
    
        public bool Val
        {
            get
            {
                return DataBaseAccesor[_ParameterName].Equals("Y").Equals(_CurrentVal);
            }
            set
            {
                _CurrentVal = value;
                DataBaseAccesor[_ParameterName] = value ? "Y" : "N";
            }
        }
