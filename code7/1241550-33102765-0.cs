    // LateUpdate is triggered after every other update is done, so this is
    // perfect place to add update logic that needs to "override" anything
    void LateUpdate() { 
      if(hasStopped) {
          hasStopped=false;
          var rigidbody = this.GetComponent<Rigidbody>();
          if(rigidbody) {
             rigidbody.isKinematic = true;
          }
      }
    }
    
    bool hasStopped;
    void OnTriggerEnter (Collider other)
    {
         if (other.gameObject.CompareTag ( "Trap" ))
         {
            var rigidbody = this.GetComponent<Rigidbody>();
            if(rigidbody) {
               // Setting isKinematic to False will ensure that this object
               // will not be affected by any force from the Update() function
               // In case the update function runs after this one xD
               rigidbody.isKinematic = false;
               // Reset the velocity
               rigidbody.velocity = Vector3.zero;
               rigidbody.angularVelocity = Vector3.zero;
               hasStopped = true;
            }
             //move object to start position
             transform.position = startposition.transform.position;
              
    
             // I want to stop the object here, after it was moved to start position.   Because my ball was moving when it hit Trap object, so when it was moved to start position, it keeps rolling.
         }
    }
