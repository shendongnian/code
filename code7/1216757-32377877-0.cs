	using UnityEngine;
	using System.Collections;
	public class HideObject : MonoBehaviour {
	public GameObject objectToHide;
	
	// Update is called once per frame
	void Update(){
		if(Input.GetButtonDown ("Fire1")){
			objectToHide.SetActive(false);
			Debug.Log("Remove");
		}
		if(Input.GetButtonDown ("Fire2")){
			objectToHide.SetActive(true);
			Debug.Log("Return");
			}
		}
	}
