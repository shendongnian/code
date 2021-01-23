private bool IsTaskRunning = false
    private void MyMethod(){
    
    if(IsTaskRunning==false){
           IsTaskRunning=true;
    
           //My heavy duty code that takes a long time
    
            IsTaskRunning=false;    //When method is finished
       }
     }
