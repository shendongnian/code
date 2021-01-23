    using UnityEngine;
    using System.Collections;
    
    public class animateSkyBox : MonoBehaviour {
    
    public Skybox sky;
    public Material skyboxmaterial; 
    float tParam = 0f;
    float valToBeLerped = 0f;
    float speed = 0.1f; 
    
    
    
    	void Start()
      {
    		skyboxmaterial.SetFloat("_Blend", 0);
      Debug.Log("Audio begins now.....");
      Invoke("TwoMinutesHasPassed", 10f);
      }
    
    void TwoMinutesHasPassed()
      {
      Debug.Log("two minutes has passed");
      Debug.Log("now i will fade the background");
      StartCoroutine("FadeNow");
      }
    
    private IEnumerator FadeNow()
      {
      tParam = 0f;
      while (tParam < 1)
        {
    	tParam +=  Time.deltaTime;  
        valToBeLerped = Mathf.Lerp(0, 1, tParam);
    			skyboxmaterial.SetFloat("_Blend", valToBeLerped);
    			yield return new WaitForSeconds(0.1f);
        Debug.Log("valToBeLerped is " + valToBeLerped.ToString("f4"));
    			 
        }
      //skyboxmaterial.SetFloat("_Blend", valToBeLerped);
      Debug.Log("fade is done.");
    		yield return valToBeLerped;
      }
    
    
    
      void Update() {
    
    
    		 
      }
      }
