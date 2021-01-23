    using UnityEngine;
    using System.Runtime.InteropServices;
    
    public class NewBehaviourScript : MonoBehaviour {
    
        [DllImport("__Internal")]
        private static extern void Hello();
    
        [DllImport("__Internal")]
        private static extern void HelloString(string str);
    
        void Start() {
            Hello(); //Call Hello from JavaScript
            
            HelloString("This is a string."); //Call HelloString from JavaScript with parameter
        }
    }
