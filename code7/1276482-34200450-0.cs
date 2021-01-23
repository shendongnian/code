    void OnCollisionEnter2D(Collision2D col) {
        Destroy (col.gameObject);
        Instantiate (cube,new Vector3(0f,4.19f,0f),Quaternion.identity);
        isFalling = false;  // here
    }
    private bool isFalling = false;  // here
    public void Fall()
    {
        GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ().isKinematic = false;
        if(isFalling == false){
            source.PlayOneShot(clip);
            isFalling = true;   // here
        }
    }
