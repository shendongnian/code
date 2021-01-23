    using UnityEngine;
    using System.Collections.Generic;
    
    public class LelExample : MonoBehaviour
    {
        public List<Vector2> Vec2List = new List<Vector2>();
        public float maxX;
    
        public void Start()
        {
            float[] x; //set temp arrays
            float[] y;
    
            GetArraysFromVecList(Vec2List, out x, out y); //set the arrays outputting x and y
    
            maxX = Mathf.Max(x); //Max the x's
        }
        public void GetArraysFromVecList(List<Vector2> list, out float[] x, out float[] y) //My Custom Void
        {
            float[] tx = new float[list.Count]; //Define temporary arrays
            float[] ty = new float[list.Count];
    
            for (int i = 0; i < list.Count; ++i)
            {
                tx[i] = list[i].x; //Add x to each corrosponding tx
                ty[i] = list[i].y; //Add y to each corrosponding ty
            }
            x = tx; //set the arrays
            y = ty;
        }
    }
