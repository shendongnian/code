    void OnCollisionEnter(Collision c)
     {
     if ( (c.gameObject.tag == "Character") )
       c.GetComponent<YourHerosCode?().ApplyPenalty()
     }
