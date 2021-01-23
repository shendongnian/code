    void Start(){
        Invoke("MoveChar", 3); //execute MoveChar() after 3 seconds
    }
    
    MoveChar(){
        panel_x = Random.Range(1,4);
        panel_y = Random.Range(1,4);
    }
