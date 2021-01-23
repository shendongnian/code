    // Attached to Either empty GO or spaceship GO
    public class PlayerInput : MonoBehaviour {
        public GameObject spaceship;
        public GameObject bulletPrefab;
        public float projectileSpeed;
        void Update()
        {
            if(Input.GetButtonDown("Fire1"))
            {
                GameObject newBullet = Instantiate(bulletPrefab, spaceship.transform.position, new Quaternion()) as GameObject;
                newBullet.GetComponent<Rigidbody>().AddForce(spaceship.transform.forward * projectileSpeed);
            }
        }
    }
    
    // Attached to Either Projectile GO
    public class Projectile : MonoBehaviour {
        
        void OnCollisionEnter()
        {
            Debug.Log("Boom");
        }
        
    }
