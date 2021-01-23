    using UnityEngine;
     using System.Collections;
     
     public class PlayerDamageReceiver : DamageableObject {
         
         //override the OnTakeDamage() method to make a 
         //different implementation of it for this class
         protected override void OnTakeDamage(float damageAmount, DamageSource damageSource) {
             Debug.Log("Ouch, the player was damaged!");
         }
         
         //Uncomment this to override the OnDeath() function 
         //in DamageableObject (if you've uncommented that, that is)
         //protected override void OnDeath(float damageAmount, DamageSource damageSource) {
         //    Debug.Log("Uhoh... The player died. :(");
         //}
         
         //override the CalculateDamage() function to 
         //determine how damage applies to the player
         protected override float CalculateDamage(float damageAmount, DamageSource damageSource) {
             //Example: give the player a 2x weakness to fire damage, and immunity to ice damage
             switch (damageSource.GetElementType()) {
                 case (ElementType.Fire):
                     damageAmount *= 2f;
                     break;
                 case (ElementType.Ice):
                     damageAmount = 0f;
                     break;
             }
             return damageAmount;
         }
     }
