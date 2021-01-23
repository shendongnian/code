    void OnCollisionEnter(Collision other)
    {
        addSelfDPS(other.gameObject.GetComponent<WallDamager>().getDPS());
    }
    void OnCollisionExit(Collision other)
    {
        addSelfDPS(-1*other.gameObject.GetComponent<WallDamager>().getDPS());
    }
