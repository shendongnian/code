    public class BasicAttak : Spell {
        public int          dmg = 2;
        public float        speed = 10.0f;
        public Rigidbody    projectile; 
        private float       currentCooldown = 0.0f;
    
        void Awake()
        {
            currentCooldown = 0.0f;
        }
    
        public override bool    launch(Vector3 launcherPosition, Vector3 targetPosition)
        {
            Debug.Log("Launch Basic Attack, cooldown = " + this.currentCooldown + " - if = " + (this.currentCooldown <= 0.0f) );
            if (this.currentCooldown <= 0.0f) {
                if (projectile == null)
                    return (false);
                Quaternion r = Quaternion.LookRotation (targetPosition - launcherPosition);
                Rigidbody shot = Instantiate (projectile, launcherPosition, r) as Rigidbody;
                ProjectileScript a = shot.GetComponent<ProjectileScript>();
                a.damage = this.dmg;
                a.speed = this.speed;
                this.currentCooldown = this.cooldown;
                Invoke("ResetCoolDown", this.cooldown);
                return (true);
            }
            return (false);
        }
    
        void ResetCoolDown()
        {
            this.currentCooldown = 0.0f;
        }
    }
