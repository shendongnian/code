    public Texture texture; // if needed for something outside this code
    private Vector3 playerPosOnScreen;
    private float mousePosInBlocks;
    public void Update () {
        playerPosOnScreen = Camera.main.WorldToScreenPoint(transform.position);
        if (playerPosOnScreen.x > Screen.Width) {
            transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.Width, transform.position.y, transform.position.z);
        } else if (playerPosOnScreen.x < 0f) {
            transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (0f, transform.position.y, transform.position.z);
        }
    }
