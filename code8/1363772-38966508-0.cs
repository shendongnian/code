    public void MovePLayer () {
            float speed = 10;
    
            rb.AddForce (v *Time.DeltaTime * speed);
            Debug.Log ("CLICKED");
    }
