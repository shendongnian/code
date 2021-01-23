    [RequireComponent(typeof(BoxCollider))]
    public class Waypoint : MonoBehaviour
    {
        public void OnTriggerEnter(Collider p_collider)
        {
            if (p_collider.tag == "Enemy")
                p_collider.GetComponent<AgentController>().NextWaypoint(this);
        }
    }
