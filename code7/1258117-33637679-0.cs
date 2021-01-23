    class C:IDisposable{
        int usageCount = 0;
        public void AddUsage(){usageCount++;}; 
        public void Dispose(){
             if(usageCount>0){
                usageCount--;
                return;
             }
			 //ELSE DO REAL DISPOSE LOGIC
        }
     }
