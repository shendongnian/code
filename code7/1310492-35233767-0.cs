    Vector3 position;
    void Update(){
        if(Input.GetMouseButtonDown(0)) { this.position = Input.mousePosition;}
        else if(Input.GetMouseButton(0)){ 
            float distance = Vector3.Distance(this.position, Input.mousePosition);
        } 
        else if(Input.GetMouseButtonUp(0)) { this.position = Vector3.zero }
    }
