    using UnityEngine;
    using System.Collections;
    
    public class MaidTriggeris : MonoBehaviour {
        public GameObject light;
        public GameObject sing;
        public GameObject ghost;
        public float speed;
        public GameObject target;
    
    
        // Use this for initialization
        void Start () {
            light.SetActive(true);
        }
    
        // Update is called once per frame
        void OnTriggerEnter(){
            light.SetActive (false);
            DestroyObject (sing);
            StartCoroutine("MoveGhost");            
        }
    
        IEnumerator MoveGhost(){
            while(Vector3.Distance(ghost.transform.position, target.transform.position) > 1.0f) // Change this value accordingly 
                {
                    float step = speed * Time.deltaTime;
                    ghost.transform.position = Vector3.MoveTowards(ghost.transform.position, target.transform.position, step);
                    yield return new WaitForEndOfFrame();
                }
        }
    }
