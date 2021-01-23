    using UnityEngine;
    using System.Collections;
    
    public class animateSkyBox : MonoBehaviour {
    
    public Skybox sky;
    public Material skyboxmaterial; 
    float tParam = 0f;
    float valToBeLerped = 0f;
    float speed = 0.3f; 
    
        // Use this for initialization
        void Start () {
    
            sky = gameObject.GetComponent<Skybox>();
            skyboxmaterial = sky.material;
    		 
    		Invoke("TwoMinutesHasPassed", 3f);
    
        }
    
       
        // Update is called once per frame
        void Update () {
        }
    
    
    	void TwoMinutesHasPassed()
      	{
    
    	if (tParam < 1) {
        tParam += Time.deltaTime * speed;  
        valToBeLerped = Mathf.Lerp(0, 1, tParam);
     	}
        skyboxmaterial.SetFloat("_Blend", valToBeLerped);
        Debug.Log("test");
      }
    }
