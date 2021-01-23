    using UnityEngine;
    using System.Collections;
    
    public class normalBoxScript : MonoBehaviour {
    
        private int counter;
        public GameObject box;
        public GameObject squezeBox;
        private Vector3 defaultScale;
        public float speed;
    	// Use this for initialization
    	void Start () {
            defaultScale = box.transform.localScale;
    	}
    	void Update () {
            Debug.Log(counter);
             updateScale();
    	}
        void OnTriggerEnter(Collider col)
        {
           if (col.tag == "Player")
            {
                counter++;
            }
        }
        void OnTriggerExit(Collider col)
        {
            if (col.tag == "Player")
            {
                counter--;
            }
        }
    
        void updateScale()
        {
            if (counter == 2)
            {
               box.transform.localScale = Vector3.MoveTowards(box.transform.localScale, squezeBox.transform.localScale, speed); 
            }
            else 
            {
                box.transform.localScale = Vector3.MoveTowards(box.transform.localScale, defaultScale, speed); 
            }
      }
     }
