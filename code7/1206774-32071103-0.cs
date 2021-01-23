    public class Player : MonoBehavior
    {
        private bool cooldown = false;
        private const float ShootInterval = 3f;
    
        void Shoot()
        {
            if (!cooldown)
            {
                cooldown = true;
    
                //and shoot bullet...
                Invoke("CoolDown", ShootInterval);
            }
        }
    
        void CoolDown()
        {
            cooldown = false;
        }
    }
