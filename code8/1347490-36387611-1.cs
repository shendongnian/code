    public class Enemy : MonoBehaviour
    {
        int health = 10;
    
        public void dealDamage(int value)
        {
            health -= value;
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
