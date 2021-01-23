    public class Price : IDataErrorInfo
    {
        private double _cost;
        public string Cost
        {
            get {
                return _cost.ToString();
            } 
            set {
                    double.TryParse(value, out _cost);
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
