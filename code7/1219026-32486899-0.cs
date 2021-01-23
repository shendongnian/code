    public static Vector3 imgRot;
	[HideInInspector] public static bool loadRot=false;
	public void OnClicked(Button button)
	{
	    imgRot = ImgRotation.rot.eulerAngles;
		imgRot.x = PlayerPrefs.GetFloat ("PlayerX");
		imgRot.y = PlayerPrefs.GetFloat ("PlayerY");
		imgRot.z = PlayerPrefs.GetFloat ("PlayerZ");
		
		loadRot= true;
		Application.LoadLevel ("1");
	}
