    using UnityEngine;
    using UnityEngine.UI;
    public class EverythingInside : MonoBehaviour
    {
        public Canvas GUICanvas;
        void OnCollisionEnter(Collision col)
        {
            if (col.tag == "FallingCube")
            {
                GUICanvas.gameObject.SetActive(true);
            }
        }
    }
