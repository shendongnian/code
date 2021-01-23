    public GameObject Cube;
    void Start()
    {
        SpawnRow(Vector3.zero, 10);
    }
    void SpawnRow(Vector3 startPosition, int RowLength)
    {
        Vector3 currentPos = startPosition;
        for (int i = 0; i < RowLength; i++)
        {
            Instantiate(Cube, currentPos, Quaternion.identity);
            currentPos.x += Cube.transform.localScale.x;
        }
    }
