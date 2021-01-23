    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    public class Training : MonoBehaviour {
	public List<KeyCode> previousActions;
	void Update(){
		if(Input.GetKeyDown(KeyCode.A)){
			Debug.Log("Do something");
			previousActions.Add(KeyCode.A);
		}else if(Input.GetKeyDown(KeyCode.S)){
			Debug.Log("Do something else");
			previousActions.Add(KeyCode.S);
		//---Check the list--//
		}else if(Input.GetKeyDown(KeyCode.D)){
			Debug.Log("Check the list");
			for(int i = 0;i < previousActions.Count;i++){
				Debug.Log(previousActions[i]);
			}
		}
	}
