     public class Price : IDataErrorInfo
    {
        private double _costDouble;
        private string _cost;
        public string Cost
        {
            get {
                return _cost;
            } 
            set {
                    _cost = value;
                    double.TryParse(value, out _costDouble);
                } 
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                string message = null;
                if (columnName == "Cost")
                {
                    double doubleVal;
                    if (double.TryParse(this.Cost, out doubleVal))
                    {
                        if (doubleVal > 1000.0)
                            message = "This price is high enough to require confirmation";
                    }
                    else {
                        message = "Format error";
                    }
                }
                return message;
            }
        }
    }
