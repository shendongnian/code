    using UnityEngine;
    using System.Collections;
    [System.Serializable]
    public class BoundaryOne 
    {
    public float xMin, xMax, yMin, yMax;
    }
    public class Done_PlayerController : MonoBehaviour
    {
	public float speed;
    //using mathf to limit bounds of movement
	public BoundaryOne boundary;
	
	
	void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0);
        GetComponent<Rigidbody>().velocity = movement * speed;
        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(0, 0, 0)
            );
        //my mobile tilt controls
        transform.Translate(Input.acceleration.x / 4, 0, 0);
    }
        
    // void Start ()
    //{
    //GetComponent<Rigidbody>().velocity = transform.right * speed;
    //}
    }
