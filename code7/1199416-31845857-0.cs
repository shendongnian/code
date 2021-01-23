    using UnityEngine;
    namespace ClassLibrary1
    {
        public class Death : MonoBehaviour
        {
            public void Add() //right here I get a "expected class, Delegate, Enum, interface, or struct" error. 
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
