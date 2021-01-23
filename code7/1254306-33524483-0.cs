    using UnityEngine;
    using System.Collections;
    
    public class ExampleClass : MonoBehaviour {
        public Animation anim;
        void Start() {
            anim = GetComponent<Animation>();
        }
        void OnMouseEnter() {
            if (!anim.IsPlaying("mouseOverEffect"))
                anim.Play("mouseOverEffect");
            
        }
    }
