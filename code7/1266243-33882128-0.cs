    using UnityEngine;
    using System.Collections;
    public class boardObject : MonoBehaviour {
	
	// Instantiates a prefab in a grid
	
	public GameObject prefab;
	public float gridX = 5f;
	public float gridY = 5f;
	public float spacing = 2f;
	public float xsize = 1.0f;
	public float ysize = 1.0f;
	
	void Start() {
		for (float y = 0; y < gridY; y++) {
			for (float x = 1; x < gridX; x++) { //<<<<<This is where the change was made to get it to work. x = 1 instead of 0.
				
				Vector3 pos = new Vector3 (x * xsize, 0.0f, y * ysize) ;
				
				Instantiate (prefab, pos, Quaternion.identity);
				if (y % 2 == 0)
					y += 1;
				else 
					y -= 1;
			}
		}
	}
	void Update() {
}
	}
