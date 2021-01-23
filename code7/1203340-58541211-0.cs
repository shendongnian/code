        public class "ClassNameHerë": MonoBehaviour
    {
        public BoxCollider2D Collider1;
        public CircleCollider2D Collider2;
        public CircleCollider2D Collider3;
    
    private void OnCollisionEnter2D(Collision2D other)
        {
                 if(other.collider==Collider1)
                {
                  Debug.Log("1");
                }
                if(other.collider==Collider2)
                {
                   Debug.Log(2);
                }
                if(other.collider==Collider3)
                {
                   Debug.Log(3)
                }      
            }
    }
