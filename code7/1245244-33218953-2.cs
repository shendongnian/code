    private Transform original;
    public float speed = 0.5f;
    void Awake()
    {
        original = transform;
    }
    void Update() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, original.position, step);
    }
