    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    public class SoundControl : MonoBehaviour {
	// Use this for initialization
	private Button note;
	void Start () {
		PlayerPrefs.SetInt ("Music", 1);
		note = GetComponent<Button> ();
	}
	
	// Update is called once per frame
	public Sprite onnote;
	public Sprite offnote;
	void Update () {
		if (PlayerPrefs.GetInt ("Music") == 1) {
			note.image.overrideSprite = onnote;
			Debug.Log("Button Music equals 1 UPdated");
		}
		if (PlayerPrefs.GetInt ("Music") == 0) {
			note.image.overrideSprite = offnote;
			Debug.Log("Button Music equals 0 UPdated");
		}
	}
	public void MakeSound()
	{
		switch(PlayerPrefs.GetInt("Music"))
		{
		case 0:
			PlayerPrefs.SetInt ("Music", 1);
			Debug.Log("Button Music equals 1");
			break;
		case 1:
			PlayerPrefs.SetInt ("Music", 0);
			Debug.Log("Button Music equals 0");
			break;
		}
	}
    }
