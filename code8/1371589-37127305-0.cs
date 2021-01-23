    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using System.Collections.Generic;
    
    public class GameController : MonoBehaviour
    {
    
    	public int coins;
    	private int spherePrice = 100, cubePrice = 50;
    
    	public GameObject player;
    	public GameObject[] availablePrefabs;
    	public List<GameObject> mySkins;
    
    	public Button btnSphere, btnCube;
    	public Text txtSphere, txtCube;
    
    	void Start ()
    	{
    		string serializedMySkins = PlayerPrefs.GetString ("skins", "");
    		string serializedPlayer = PlayerPrefs.GetString ("player", "");
    
    		// skins desserialization
    		if (serializedMySkins == "")
    			mySkins = new List<GameObject> ();
    		else {
    			var a = serializedMySkins.Split (',');
    			for (int i = 0; i < a.Length; i++) {
    				if (a [i] == "Sphere") {
    					mySkins.Add (availablePrefabs [0]);
    				} 
    
    				if (a [i] == "Cube") {
    					mySkins.Add (availablePrefabs [1]);
    				} 
    			}
    		}
    
    		// player desserialization
    		if (serializedPlayer != "") {
    			if (serializedPlayer == "Sphere") {
    				player = availablePrefabs [0];
    			} 
    
    			if (serializedPlayer == "Cube") {
    				player = availablePrefabs [1];
    			} 
    		} else {
    			player = mySkins [0];
    		}
    
    		coins = PlayerPrefs.GetInt ("coins", 0);
    		coins = 1000;
    	}
    
    	void Update ()
    	{
    		if (mySkins.Contains (availablePrefabs [0])) { 
    			txtSphere.text = "Usar esfera";
    		} else {
    			btnSphere.interactable = coins >= spherePrice;
    		}
    
    		if (mySkins.Contains (availablePrefabs [1])) {
    			txtCube.text = "Usar cubo";
    		} else {
    			btnCube.interactable = coins >= cubePrice;
    		}
    	}
    
    	public void play ()
    	{
    		player = (GameObject)Instantiate (player, new Vector2 (0, 0), Quaternion.identity);
    	}
    
    	public void verifySkin (GameObject skinPrefab)
    	{
    		if (mySkins.Contains (skinPrefab)) {
    			useSkin (skinPrefab);
    		} else if (coins >= priceOf (skinPrefab)) {
    			buySkin (skinPrefab, priceOf (skinPrefab));
    		}
    	}
    
    	public void buySkin (GameObject skinPrefab, int price)
    	{
    		mySkins.Add (skinPrefab);
    		coins -= price;
    
    		string skinsHash = "";
    		for (int i = 0; i < mySkins.Count; i++) {
    			skinsHash += mySkins [i].name + ",";
    		}
    
    		Debug.Log (skinsHash);
    
    		PlayerPrefs.SetInt ("coins", coins);
    		PlayerPrefs.SetString ("skins", skinsHash);
    
    		PlayerPrefs.Save ();
    	}
    
    	public void useSkin (GameObject skinPrefab)
    	{
    		player = skinPrefab;
    		PlayerPrefs.SetString ("player", player.name);
    		PlayerPrefs.Save ();
    	}
    
    	private int priceOf (GameObject skinPrefab)
    	{
    		if (skinPrefab == availablePrefabs [0])
    			return spherePrice;
    		else if (skinPrefab == availablePrefabs [1])
    			return cubePrice;
    		else
    			return 0;
    	}
    }
