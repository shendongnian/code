    // Attach this script to gameObject that will be affected by gravity
    // Ensure gameObject has rigidbody component attached and "Use Gravity" is UNCHECKED
    public class GravityScript : MonoBehaviour
    {
    
        Rigidbody rigidbody;
        Transform[] gravitySources; // Assign each Transform in inspector, these will be sources of gravity.
        
        void Start ()
        {
            rigidbody = GetComponent<Rigidbody>();
        }
        
        // NOTE: Include proper individual gravitational forces (gravity from far away objects is weaker than gravity from closer objects)
        private Vector3 CalculateGravity()
        {
            Vector3 gravity = Vector3.zero;
        
            // For each source of gravity accumulate total gravitational force
            foreach (Transform source in gravitySources)
            {
                // Direction of gravity
                Vector3 direction = transform.position - source.position;
                // Calculate strength of gravity at distance
                float gravitationalStrength = Vector3.Distance(transform.position, source.position) * ????;
                gravity += direction.normalized * gravitationalStrength;
            }
        
            return gravity;
        }
        
        void FixedUpdate ()
        {
            Vector3 gravity = CalculateGravity();
            rigidbody.AddForce(gravity, Forcemode.Acceleration);
        }
    }
