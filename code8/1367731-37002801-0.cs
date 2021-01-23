    public GameObject helicopterChild;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Virtaliot") 
        {
            helicopterChild.SetActive(True); //Show the hat on the players head
            Destroy(col.gameObject); //Destroy the pickup shown in the world
            // you will also need to make the player fly up
        }
    }
