    public class Test: MonoBehaviour
    {
    	public Models [] models;
    	private int index = 0;
    	[SerializeField] private MeshFilter meshFilter = null;
    	[SerializeField] private Renderer rend = null;
    	void Update()
    	{
    		if(Input.GetKeyDown(KeyCode.Space))
    		{
    			if(++index == models.Length)index = 0;
    			meshFilter.mesh = models[index].mesh;
    			int currIndex = models[index].currentIndex;
    			rend.material = models[index].materials[currIndex];
    		}
    		if(Input.GetKeyDown(KeyCode.A))
    		{
    			if(++models[index].currentIndex == models[index].materials.Length)models[index].currentIndex = 0;
    			int currIndex = models[index].currentIndex;
    			rend.material = models[index].materials[currIndex];
    		}
    	}	
    }
    [System.Serializable]
    public class Models{
    	public Mesh mesh;
    	public int currentIndex;
    	public Material[]materials;
    }
