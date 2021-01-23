    // this script is exactly the same as yours, nothing's wrong here
    // oh except add public to function UnloadMenu, so it can be called
    // in the quizbutton script
    public GameObject quizButton;
    public void UnloadMenu() {
    	quizButton.guiTexture.enabled = false;
    }
