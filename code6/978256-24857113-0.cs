    float timer = 0.0f;
    void Update()
    {
        if (HP != 0)
        {
           timer += Time.deltaTime;
           if (timer >= 3)
           {
               panel_x = Random.Range(1, 4);
               panel_y = Random.Range(1, 4);
               timer = 0;
           }
        }
    }
