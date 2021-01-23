    void OnCollisionEnter2D(Collision2D collision)
    {
        foo<Collision2D>(collision);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        foo<Collider2D>(collider);
    }
    public void foo<T>(T c)
    {
        GameObject g;
        if (typeof(T) == typeof(Collider2D))
        {
            Collider2D obj = (Collider2D)(object)c;
            g = obj.gameObject;
        }
        else {
            Collision2D obj = (Collision2D)(object)c;
            g = obj.gameObject;
        }
        Debug.Log(g.tag);
        if (g.tag == "coin")
        {
            
        }
    }
