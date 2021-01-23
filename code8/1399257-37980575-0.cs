    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Destroyable")
        {
            Destroy(other.gameObject);
        }
    }
