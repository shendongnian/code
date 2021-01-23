    using UnityEngine;
    using System.Collections;
    using UnityEngine.SceneManagement;
    public class start_new_game : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
	}
	public void LoadSceneMode()
	{
		if (Input.GetMouseButton(0)) {
			SceneManager.LoadScene(0);
		}
	 }
    }
