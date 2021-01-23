    void ApplyPenalty()
     {
     yourPauseSystem = true;
     Debug.Log("starting penalty..");
     Invoke("EndPenalty", 5f);
     }
    
    void EndPenalty()
     {
     yourPauseSystem = false;
     Debug.Log("    ...ended penalty");
     }
