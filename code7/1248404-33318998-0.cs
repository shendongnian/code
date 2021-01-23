    string lastTagCollided = "";
    public Rigidbody rb;
    
    void OnCollisionEnter(Collision col)
    {
    	Debug.Log("Debug 1: Collision " + col.gameObject.tag);
        if(col.gameObject.tag == "Pentagon" && lastTagCollided == "Pyramid")
        {
    	Debug.Log("Debug 2: col.gameObject.tag == \"Pentagon\" && lastTagCollided == \"Pyramid\" results true - Collision " + col.gameObject.tag);
            rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            transform.DetachChildren();
            Destroy (GameObject.FindWithTag("Sphere"));
        }
    
        if(col.gameObject.tag == "Pyramid" && lastTagCollided == "Pentagon")
        {
    	Debug.Log("Debug 3: col.gameObject.tag == \"Pyramid\" && lastTagCollided == \"Pentagon\" results true - Collision " + col.gameObject.tag);
            rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            transform.DetachChildren();
            Destroy (GameObject.FindWithTag("Sphere"));
        }
    
        lastTagCollided = col.gameObject.tag;
    }
    }
