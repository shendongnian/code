    using UnityEngine;
    using System.Collections;
    public class Sword : MonoBehaviour {
	public float totalhealth = 100;
	
	public void OnTriggerEnter(Collider other){
		if(other.tag == "angelic_sword_02"){
			totalhealth -= 50;
		}
	}
	
	void Update(){
		if(totalhealth <= 0){
			Destroy(gameObject);
		}
	}
    }
