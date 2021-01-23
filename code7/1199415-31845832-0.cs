    using UnityEngine;
    
    namespace GOTY2015 
    {    
        public class Death : MonoBehaviour
        { 
            public void Add() 
            { 
                if (isDead) 
                {
                    DeathCamTag.SetActive(true); 
                }
                else 
                {
                    FPSControllerTag.SetActive(true);   
                } 
            }
        }   
    }
