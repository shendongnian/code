      Public GameObject origin;
     void OnParticleCollision(GameObject other) {          
         if(other.GetInstanceID() != origin.GetInstanceID())
             DoSomething();
                  }
