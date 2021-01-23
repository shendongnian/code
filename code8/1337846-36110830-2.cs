    void OnTriggerEnter (Collider CC)
    {
        if (CC.gameObject.tag == "CC") 
        {
            Debug.Log ("Combat Chance Roll");
            isCombat = false;
            CombatChance = Random.Range (1, 100);
            Probability = 20;
    
            if (CombatChance <= Probability) {
                isCombat = true;
                isCombat2 = true;
            } else {
                isCombat = false;
                isCombat2 = false;
            }
        }
