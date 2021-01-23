    IEnumerator ShowHitCounter(string message)
    {
        GUIHit.text = message;
        GUIHit.enabled = true;
    }
    void ClearLabel()
    {
        HitCounter = 0; 
        GUIHit.enabled = false;
    }
