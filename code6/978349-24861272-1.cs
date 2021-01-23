    void OnTriggerEnter(Collider collider){
        // detect if the object enters the area
        if(collider.GameObject.name == "Your Object"){
            // get object's script and modify its variable
            ObjectScript obj = collider.GameObject.GetComponent<ObjectScript>();
            obj.areaReached = true;
        }
    }
    void OnTriggerExit(Collider collider){
        // set it back to false if the object leaves the area before OnMouseUp
        if(collider.GameObject.name == "Your Object"){
            ObjectScript obj = collider.GameObject.GetComponent<ObjectScript>();
            obj.areaReached = false;
        }
    }
