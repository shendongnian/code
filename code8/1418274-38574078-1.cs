    using UnityEngine;
    using System.Collections;
    
    public class AssignShadersToChildren : MonoBehaviour 
    {
        public Shader shader; // This should hold the Shader you want to use
        
        void Start() 
        {
            // We create a list that will hold all the renderers so we can then assign the shader
            List<Renderer> renderers = new List<Renderer>();
            renderers = GetComponentsInChildren<Renderer>();
    
            // For every Renderer in the list assign the materials shader to the shader
            foreach (Renderer r in renderers) {
                r.material.shader = shader;
            }
        }
    }
