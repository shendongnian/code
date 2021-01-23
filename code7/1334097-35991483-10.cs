    public YourRingControllScript ringController;
    void OnTriggerEnter(Collider other) {
         if (other.gameObject.name == "Sphere") {            
               Debug.Log ("Hit Sphere");
               ringController.shouldMove = false; ///Change shouldMove
         }
    }
