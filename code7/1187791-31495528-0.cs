    using UnityEngine;
    using System.Collections;
    public class EnemyPatrol : MonoBehaviour
    {
        void Update()
        {
            this.transform.Translate(Input.GetAxis("Horizontal"), 0, 0);
        }
    }
