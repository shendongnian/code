    public int NumberOfClicks;
    private bool Invoked;
    void Start(){
        Invoked = false;
    }
    
    void Update(){
        if(NumberOfClicks == 1 && !Invoked){
            gameObject.name = "crosshair";
            Invoke("RevertToZero", 2);
            Invoked = true;
        }
        if(NumberOfClicks == 2 ){
            gameObject.name = "boom";
        }
    }
    
    void RevertToZero(){
         NumberOfClicks = 0;
         Invoked = false;
    }
