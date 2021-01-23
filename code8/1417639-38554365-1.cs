    DateTime invincible = DateTime.Now;
    
    public void Damage(int dmg)
    {
        if(invincible <= DateTime.Now)
        {
            curHealth -= dmg;
            Reset();
        }
    }
    
    void Reset ()
    {
        transform.position = startPosition;
        PlayerMovement.target = startPosition;
        invincible = DateTime.Now.AddSeconds(5);
    }
