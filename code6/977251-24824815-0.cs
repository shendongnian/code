    private boolean displayMusic = false;
    private boolean musicOn = true;
    void OnGUI() {
        if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 2, 150, 50), "Settings")) {
            displayMusic = true; //If the settings button is clicked, display the music
            // Here you could replace the above line with
            // displayMusic = !displayMusic; if you wanted the settings button to be a
            // toggle for the music button to show
        }
        if (displayMusic) { //If displayMusic is true, draw the Music button
            if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 2 + 50, 150, 50), "Music " + (musicOn ? "On" : "Off"))) {
                musicOn = !musicOn; //If the button is pressed, toggle the music
            }
        }
    }
