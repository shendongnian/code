    public int NumberOfClicks;
    
    void Update(){
        if(NumberOfClicks == 1){
            gameObject.name = "crosshair";
            Invoke("RevertToZero", 2);
        }
        if(NumberOfClicks == 2){
            gameObject.name = "boom";
        }
    }
    
    void RevertToZero(){
         NumberOfClicks = 0;
    }
