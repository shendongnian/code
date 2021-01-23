    using UnityEngine;
    using FooNamespace;
    public class GonnaCallWeapon : MonoBehaviour {
        public Weapon weapon;
	    void Start () {
            weapon.LogMeUp();
            Debug.Log("I called LogMeUp");
	    }
    }
