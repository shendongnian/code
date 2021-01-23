        public Decimal TransactCredit
        {
            get
            {
                return _TransactCredit;
            }
    
            
    
            set
    		{
    			if (TransactionType == 1)
    			{
    				SetPropertyValue("TransactCredit", ref _TransactBalance, value);
    			}
    	
    			else 
    			{
    				SetPropertyValue("TransactCredit", ref _TransactCredit, value);
    			}
    		}
    
        }
