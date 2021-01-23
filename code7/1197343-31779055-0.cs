    public AudioClip A1;
    void  OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Button1")
            AudioSource.PlayClipAtPoint (A1, transform.position);
    }
