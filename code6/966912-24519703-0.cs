    public float frequency = 1.0f; // in Hz
    public Vector3 positionA;
    public Vector3 positionB;
    private float elapsedTime = 0.0f;
    public void Update()
    {
        elapsedTime += Time.deltaTime;
        float cosineValue = Mathf.Cos(2.0f * Mathf.PI * frequency * elapsedTime);
        transform.position = positionA + (positionB - positionA) * 0.5f * (1 - cosineValue);
    }
