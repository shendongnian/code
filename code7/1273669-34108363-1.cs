    using UnityEngine;
     using System.Collections;
     
     public class DamageableObject : MonoBehaviour {
         protected bool wasRecentlyHit;
         protected float health;
         protected float maxHealth;
         
         public void Awake() {
             health = maxHealth;
         }
         
         //Creating a virtual void method lets you choose whether 
         //or not you want to set it in a derived class.
         //Here, we track the amount of damage and the source 
         //the damage came from. This can sometimes be handy for 
         //context-sensitive reactions to being damaged. Eg, play 
         //a particular sound in damaging the player, when 
         //successfully damaged by a particular attack.
         //Note that this base implementation does nothing - you 
         //override it in an inheriting class, very similar to using Update() etc.
         protected virtual void OnTakeDamage(float damageAmount, DamageSource damageSource) {}
         //An example of how you'd check whether damage is incoming. 
         //You can alternatively just call 
         //someDamageableObject.TryDoDamage() from another script.
         public void OnTriggerEnter(Collider other) {
             DamageSource damageGiver = other.GetComponent<DamageSource>();
             if (damageGiver) {
                 TryDoDamage(damageGiver.GetDamageAmount(),damageGiver.gameObject);
             }
         }
         public void TryDoDamage(float damageAmount, GameObject damageGiver) {
             //early out, this DamageableObject was damaged a very 
             //short time ago and shouldn't be damaged again so soon
             if (wasRecentlyHit) return;
             
             //optionally perform any damage calculations here based
             //on the damageGiver, eg more damage from the player 
             //being weakened somehow, or less damage from type 
             //resistances... etc.
             damageAmount = CalculateDamage(damageAmount,damageGiver);
             
             //if after our damage calculations we still have an 
             //amount of damage greater than 0, we do the damage and 
             //send the OnTakeDamage() message.
             if (damageAmount>0f) {
                 health -= damageAmount;
                 
                 //optional handling of dying (uncomment this and the OnDeath() function to enable)
                 //if (health<0f) {
                 //    OnDeath(damageAmount,damageGiver);
                 //}
                 //else {
                 OnTakeDamage(damageAmount,damageGiver);
                 //}
             }
         }
         
         //Uncomment this and the (healtn<0f) if statement above 
         //if you want to handle dying as well as being damaged
         //protected virtual void OnDeath(float damageAmount, DamageSource damageSource);
         
         //Default implementation for calculating damage, 
         //given some amount of damage, and some source of damage.
         //Override this in an inheriting class if you want to do 
         //different damage, eg based on the damage source (2x 
         //damage from fire attacks, 0.5x damage from ice 
         //attacks... etc) or based on the DamageableObject's 
         //current state (eg, player is weakened, so takes 1.5x damage)
         protected float CalculateDamage(float damageAmount, DamageSource damageSource) {
             return damageAmount;
         }
     }
 
