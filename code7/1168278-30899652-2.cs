    using UnityEngine;
    using System.Collections;
    public class BotonIrAInstrucciones : MonoBehaviour
    {
        // Use this for initialization
        void Start () { }
        // Update is called once per frame
        void Update () { }
        public void OnCollisionEnter(Collision col)
        {
            Application.LoadLevel("Next Level");
        }
    }
