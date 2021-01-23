     using UnityEngine;
     using System.Collections;
     using System.Collections.Generic;
     
     public static class HandyExtensions
         {
         public static float Jiggled(this float ff)
             {
             return ff * Random.Range(0.9f,1.1f);
             }
         }
