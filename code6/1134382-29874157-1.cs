     PlayerController obj = new PlayerController();
     void OnTriggerEnter2D(Collider2D collider) {
         if (collider.tag == "Player")
         {
             Debug.Log("Player is Re-Fueling"); 
             obj.AddFuel(1);
         }
