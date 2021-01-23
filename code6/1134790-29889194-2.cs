    void Start ()
    {
        for (int i = 0 ; i < 6 ; i++)
        {
            ts[i] = GameObject.FindGameObjectsWithTag(string.Format("T{0}", i));
        }
    }
