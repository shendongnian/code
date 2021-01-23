    void OnMouseDown(){
        // save the original position for later use
        originalPosition = gameObject.transform.position;
        ....
    }
    
    void OnMouseUp(){
        if(drag){
            if(!areaReached)
                gameObject.transform.position = originalPosition;
            // i don't see you set drag to false in your code,
            // when user has released his click, he cannot drag anymore
            // set it to false
            drag = false;
        }
    }
