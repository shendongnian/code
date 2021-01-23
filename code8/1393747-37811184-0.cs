    public class Insurance
    {
        #region Data
        private decimal Cost{get{return this.CurrentCost.Amount;} set{this.CurrentCost.Amount = value;}}
        private string Currency{get{return this.CurrentCost.Currency;} set{this.CurrentCost.Currency = value;}}
        #endregion
    
    
        public string Id {get;set;}
    
        //Changed prop name to not confuse it with storage columns
        public Money CurrentCost {get;set;}
    
        public Insurance(){
            //initialize this so that it won't blow up on mapping
            this.CurrentCost = new Money();
        }
    }
