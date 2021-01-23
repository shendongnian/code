    public class Player : MonoBehaviour , IDamageable{
         int health = 20;
         public EventHandler <EventArgs> RaiseDeathEvent;
         protected void OnDeath(EventArgs arg){
              if(RaiseDeathEvent != null) RaiseDeathEvent(this, arg);
         }
         public void Damage(int damage){
             this.health -= damage;
             if(this.health < 0){
                 Died();
                 OnDeath(null);
             }
         }
    }
