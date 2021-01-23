    using Holoville.HOTween;
    ...
    
    int displayScore = 0;
    public void updateScore (int newScore)
    {
        if (oldScore != newScore) 
        {
            float transitionTime = .2f;
            HOTween.To(this, transitionTime, "displayScore", newScore);
        }
    }
    public void Update() {
        guiText.text = "" + displayScore
    }
