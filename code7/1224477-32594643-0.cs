    public class User 
    {
        public string ImageName { get; set; }
        private string _PartName = "";
        public string PartName
        {
            get
            {
                return this._PartName; 
            }
            set { 
                _PartName=value; 
            }
        }
        public List <ArrayPosition> ArrayPositions { get; set; }
        public override string ToString()
        {
            return this.PartName.ToString();
        }
    }
    public class ArrayPosition 
    {
        public string myArrayPos = "";
        public string PartId { get; set; }
        public string ArrayPos
        {
            get
            {              
                return this.myArrayPos;                 
            }
            set
            {
                this.myArrayPos = value;
            }
        }
        public List<ExpressionMember> ExpressionMembers { get; set; }
    }        
    public class ExpressionMember
    {
        private ArrayPosition _parentArrayPosition;
        public string ExpressionMem { get; set; }
        public string MyExpressionMemValye="";            
        public string ExpressionMemValue
        {
            get
            {
                return MyExpressionMemValye;                
            }
            set
            {                   
                MyExpressionMemValye = value;
                this._parentArrayPosition.ArrayPos = value;
            }
            
            public ExpressionMember(ArrayPosition parent) {
                _parentArrayPosition = parent;
            }
        }          
    }
