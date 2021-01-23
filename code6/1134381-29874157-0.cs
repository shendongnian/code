     void OnTriggerEnter2D(Collider2D collider) {
         if (collider.tag == "Player")
         {
             Debug.Log("Player is Re-Fueling");
             PlayerController obj = new PlayerController();
             obj.AddFuel(1);
         }
