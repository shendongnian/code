    public class TestLineRenderer : MonoBehaviour {
	public GameObject lineDrawPrefabs; // this is where we put the prefabs object
	
	private bool isMousePressed;
	private GameObject lineDrawPrefab;
	private LineRenderer lineRenderer;
	private List<Vector3> drawPoints = new List<Vector3>();
	
	// Use this for initialization
	void Start () {
		isMousePressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1))
		{
			// delete the LineRenderers when right mouse down
			GameObject [] delete = GameObject.FindGameObjectsWithTag("LineDraw");
			int deleteCount = delete.Length;
			for(int i = deleteCount - 1; i >= 0; i--)
				Destroy(delete[i]);
		}
		if(Input.GetMouseButtonDown(0))
		{
			// left mouse down, make a new line renderer
			isMousePressed = true;
			lineDrawPrefab = GameObject.Instantiate(lineDrawPrefabs) as GameObject;
			lineRenderer = lineDrawPrefab.GetComponent<LineRenderer>();
			lineRenderer.SetVertexCount(0);
		}
		else if(Input.GetMouseButtonUp(0))
		{
			// left mouse up, stop drawing
			isMousePressed = false;
			drawPoints.Clear ();
		}
		if(isMousePressed)
		{
			// when the left mouse button pressed
			// continue to add vertex to line renderer
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (!drawPoints.Contains (mousePos)) 
			{
				drawPoints.Add (mousePos);
				lineRenderer.SetVertexCount (drawPoints.Count);
				lineRenderer.SetPosition(drawPoints.Count - 1, mousePos);
			}
		}
	}
