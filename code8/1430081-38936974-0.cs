    public void SwingingSword()
    {
     isSwingingSword = true; // make it false when not swinging the sword.
    }
    
    void OnTriggerEnter(Collider col)
    {
      hit = true; // not sure what it's job here
      
      if (isSwingingSword && hit)
      {
       if (col.GetComponent<Collider>().tag == "enemy")
       {
        Destroy(col.gameObject);
       }
      }
    }
