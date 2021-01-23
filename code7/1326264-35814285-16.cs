       [System.NonSerialized] public bool isConnectedNow;
       void OnCollisionEnter(Collision collision)
          GameObject theThingWeCaught = collision.gameObject
          Debug.Log("We caught this thing .. " + theThingWeCaught.name)
          theThingWeCaught ... set kinematic
          theThingWeCaught ... probably disable the rigidbody
          theThingWeCaught ... probably disable the collider
          isConnectedNow = true;
