        public void YourButtonClickedMethod()
        { 
             if(SomeObject.IsHoldAllreadyExecuted)
             {
                 SomeObject.IsHoldAllreadyExecuted = false; //set it to false for the next run 
             }
             else 
             {
                 //DO the stuff you want to
             }
        }
