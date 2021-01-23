    using UnityEngine;
    using System.Collections;
    public class DestroyCubes : MonoBehaviour
    {
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "fallingObject")
        {
            Destroy(col.gameObject);
        }
    }
    }
