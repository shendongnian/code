    public GameObject head; // drag the Head gameobject to here or you can just get it from the start
    
    void Start()
    {
        if (!head) // if you didn't drag the gameobject
        {
            head = FindObjectOfType<CardboardHead>().gameObject;
        }
    }
    
    void Update()
    {
        transform.position += speed * head.transform.forward; // it is better to multiply by Time.deltaTime
    }
