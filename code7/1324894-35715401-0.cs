    void Awake()
    {
        Transform transform = gameObject.GetComponent<Transform>();
        for (float i = 1; i < 8; i++)
        {
            for (float j = 1; j<8;j++)
            {
                Instantiate(gameObject, transform.position + new Vector3(i * 1.41f, 0, j * 1.34f), new Quaternion(0, 0, 0, 0));
            }
        }
    }
