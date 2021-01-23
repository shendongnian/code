    public void Awake()
    {
        // previous code
            var button = SongListPrefab.GetComponent<Button>();
            if (button != null)
                button.onClick.AddListener(() => lol(TempInt, button));
    }
	public void lol(int buttonNo, Button button)
    {
	    //Play Audio Onclick
	    GetComponent<AudioSource>().clip = myMusic[buttonNo] as AudioClip;
	    GetComponent<AudioSource>().Play();
	
	    //Change Color Onclick, << Problem starts here only the last array gets coloured
	    button.image.color = Color.red;
	}
