    void Update () 
    {
        if (Input.GetMouseButtonDown ("Fire1")) 
        {
            for (int i = 0; i < 10; ++i){
                Instantiate(m_oMyPrefab, m_oMyPosition, m_oMyRotation);
            }
        }
    }
