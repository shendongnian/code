    void Update()
    {
        int touches = Input.touchCount;
        Debug.Log(touches);
    
        for (int i = 0; i < touches; i++)
        {
            if (touches > 0 && Input.GetTouch(i).phase == TouchPhase.Began)
            {
                clk.PlayOneShot(imp, 0.7f);
                break;
            }
        }
    
        if (Input.GetMouseButtonDown(0))
        {
    
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(jumpForce);
        }
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            Die();
        }
    }
