    public Transform original;
    public float speed = 1f;
    void Update() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, original.position, step);
    }
