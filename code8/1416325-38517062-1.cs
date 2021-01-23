    public GameObject MCube;
    public Stack MCubeStack = new Stack();
    public Color[] MColors;
    public int MCubeCount;
    private int _mColorCount
    {
        get
        {
            return MColors.Length;
        }
    }
	// Use this for initialization
	void Awake () {
        StartCoroutine(GenerateCube());
	}
    IEnumerator GenerateCube() {
        for (int i = 0;i< MCubeCount; i++)
        {
            GameObject Cube = Instantiate<GameObject>(MCube);
            Cube.GetComponent<MeshRenderer>().material.color = Lerp4(MColors[0], MColors[1], MColors[2], MColors[3],i);
            Cube.name = i.ToString();
            Cube.transform.position = new Vector3(0f, 0.25f * i, 0f);
            MCubeStack.Push(Cube);
            yield return new WaitForEndOfFrame();
        }
    }
    private Color32 Lerp4(Color32 a, Color32 b, Color32 c, Color32 d, int t)
    {
        float r = (float)(_mColorCount - 1);
        if (t <= MCubeCount / r)
            return Color.Lerp(a, b, (float)t / r);
        else if (t < MCubeCount / r * 2f)
            return Color.Lerp(b, c, (t - MCubeCount / r) / 3f  );
        else
            return Color.Lerp(c, d, (t - MCubeCount / r * 2f) / (_mColorCount - 1));
    }
