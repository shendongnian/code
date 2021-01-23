    public class Test : MonoBehaviour
    {
    	public float originGizmoRadius = 1f;
    	public float newDotPositionGizmoSize = 0.5f;
    	public float directionLength = 2f;
    
    	Vector3 origin;
    	Vector3 direction;
    	Vector3 newDotPosition;
    
    	void Update()
    	{
    		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    
    		origin = mouseRay.origin;
    		direction = mouseRay.direction;
    
    		newDotPosition = origin - direction / direction.y * origin.y;
    	}
    
    	void OnDrawGizmos()
    	{
    		Gizmos.color = Color.red;
    		Gizmos.DrawSphere(origin, originGizmoRadius);
    		Gizmos.DrawLine(origin, origin + (direction.normalized * directionLength));
    
    		Gizmos.color = Color.green;
    		Gizmos.DrawCube(newDotPosition, newDotPositionGizmoSize * Vector3.one);
    	}
    }
