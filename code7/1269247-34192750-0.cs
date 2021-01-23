    using UnityEngine;
    using System.Collections;
    
    public class touchableGameobject : MonoBehaviour
    {
        public Color defaultColor;
        public Color selectedColor;
        private Material mat;
     
        void Start()
        {
            mat = GetComponent<Renderer>().material;
        }
     
        void onTouchDown()
        {
            mat.color = selectedColor;
        }
     
        void onTouchUp()
        {
            mat.color = defaultColor;
        }
     
        void onTouchStay()
        {
            mat.color = selectedColor;
        }
     
        void onTouchExit()
        {
            mat.color = defaultColor;
        }
    }
