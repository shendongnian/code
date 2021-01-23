    using UnityEngine;
    using System.Collections;
    
    public class ExampleClass : MonoBehaviour {
        void ApplyDamage(float damage) {
            print(damage);
        }
        void Example() {
            gameObject.SendMessage("ApplyDamage", 5.0F);
        }
    }
