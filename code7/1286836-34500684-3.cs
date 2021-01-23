    public void Bullet:MonoBehaviour{
        public int damage = 10;
        // it is hitting either from raycast or collision or else
        void OnHit(GameObject collidedObject){
            IDamageable dam = collidedObject.GetComponent<IDamageable>();
            // if you hit a wall or no damageable item, it will be false
            if(dam != null) {
                dam.Damage(damage);
            }
        }
    }
