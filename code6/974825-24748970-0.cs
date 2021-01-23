    void Update(){
       foreach(Touch touch in Input.touches) {
          if(touch.phase == TouchPhase.Ended) {
             Ray ray = Camera.main.ScreenPointToRay(touch.Position);
             if (Physics.Raycast(ray, out hit)) {
                if(hit.GameObject.name == "Button")
                   //do something
             }
          }
       }
    }
