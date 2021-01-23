    public float speed = 5.0f;
    public void Update()
    {
        Vector3 moveDelta = new Vector3(0f, Input.GetAxis("Vertical"), 0f);
        transform.Translate(moveDelta * speed * Time.deltatime)
    }
