    //public Collider a;   
    public Text text;
    
    void Update(){
       //dont need to use Update.
    }
    
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "object"){
            //set text whatever you want.
        }
    }
