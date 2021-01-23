     void Update ()  /// Not update
     {
           if (grounded && Input.GetKeyDown(KeyCode.Space))
           {
               anim.SetBool("Ground", false);
               GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
           }
      }
