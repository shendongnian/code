    void Awake(){
        if(this is IGetNews){
            FindObjectOfType<GetNewsManager>().RegisterNewsObject(this);
        }
    }
    
    void OnDestroy(){
        if(this is IGetNews){
            FindObjectOfType<GetNewsManager>().UnregisterNewsObject(this);
        }
    }
