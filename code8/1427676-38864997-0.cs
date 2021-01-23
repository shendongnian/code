    using UnityEngine;
    using System.Collections;
    
    public class testScript  : MonoBehaviour
    {
        int i = 1;
        // Use this for initialization
        void Start()
        {
    
            for (i = 1; i > 6; i++)
            {
    
                Debug.Log("value of i = " + i);
    
            }
    
            Debug.Log("i'm out of the loop");
    
        } //the problem is cs1513 c# expected unity here(21.line)
    
        // Update is called once per frame
        void Update()
        {
    
        }
    }//<====This you missed.
