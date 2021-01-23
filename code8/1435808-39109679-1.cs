    using UnityEngine;
    using System.Collections;
    public class PlayStop : MonoBehaviour
    {
        public GameObject Cube;
        void PS()
        {
            //Will search in Cube game object for component of Animation type
            Cube.GetComponent<Animation>().Play();
        }
    }
