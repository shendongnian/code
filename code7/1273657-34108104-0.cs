	public void lol(int buttonNo, Button button){
	//Play Audio Onclick
	GetComponent<AudioSource>().clip = myMusic[buttonNo] as AudioClip;
	GetComponent<AudioSource>().Play();
	
	//Change Color Onclick, << Problem starts here only the last array gets coloured
	Image[] lel = SongListPrefab.GetComponentsInChildren<Image>();
	button.color = Color.red;
	}
