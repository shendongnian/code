    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.name.Contains("CheckPoint"))
        {
            col.gameObject.SetActive(false);
            Target = FindClosestTarget ().transform;
        }
    }
