    public class Player : MonoBehavior
    {
        private float cooldown = 0;
        private const float ShootInterval = 3f;
        void Shoot()
        {
            if(cooldown > 0)
                return;
            // shoot bullet
            cooldown = ShootInterval;
        }
        void Update() 
        {
            cooldown -= Time.deltaTime;
        }
    }
