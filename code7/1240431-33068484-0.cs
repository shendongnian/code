     void OnTriggerEnter (Collider tag)
     {
         if(gameObject.tag == "Player")
         {
             JousterMove jm = gameObject.GetComponent <JousterMove> ();
            jm.spline = new Spline(somePoint, someOtherPoint, someAnchor, someOtherAnchor);
         }
     } 
