    public class myClass
    {
        private string _setString;
        public string setString 
        {
                get
                {
                     return _setString;
                 }
                set
                {
                     AuditTrail +=  value;
                     _setString = value;
                }
        }
    
        public string AuditTrail{get;set;}
