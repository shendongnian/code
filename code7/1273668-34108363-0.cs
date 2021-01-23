    using UnityEngine;
     using System.Collections;
     
     public class DamageSource : MonoBehaviour {
         protected float damageAmount = 10f;
         
         //not 100% necessary, but handy for an example of how to 
         //handle damage based on the attacker (which is 
         //relevant for info sent in the OnTakeDamage() method
         protected ElementType elementType = ElementType.Normal;
         
         //we use a function for getting the damage this 
         //DamageSource can do because it lets us overwrite it.
         //Eg, if the enemy is weakened, you can factor that 
         //in and return a lesser amount of damage.
         public float GetDamageAmount() {
             return damageAmount;
         }
         
         public ElementType GetElementType() {
             return elementType;
         }
     }
     
     //kinds of elements available for damage / resistance calculations
     public enum ElementType {
         Normal,
         Fire,
         Ice,
         Lightning
     }
 
