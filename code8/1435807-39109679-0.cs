    using UnityEngine;
    using System.Collections;
    public class PlayStop : MonoBehaviour
    {
        public GameObject Cube;
        void PS()
        {
            Cube.GetComponent<Animation>().Play();
        }
    }
