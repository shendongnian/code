    for (int i = 0; i < rolls.Count; i++) {
        int box = output.Length + 1;                            // Score box 1 to 21 
        if (rolls[i] == 0) {                                    // Always enter 0 as -
            output += "-";
            Instantiate(strick, location, rotation);  
            
            //strick.enabled = true;
            Debug.LogError("Better Luck Next Time");
        } else if (box % 2 == 0 && rolls[i-1]+rolls[i] == 10) { // SPARE anywhere
            output += "/";  
            Debug.LogError("Its Spare");
        } else if (box >= 19 && rolls[i] == 10) {               // STRIKE in frame 10
            output += "X";
            Debug.LogError("Congo you got Strick");
        } else if (rolls[i] == 10) {                            // STRIKE in frame 1-9
            output += "X ";
            Debug.LogError("Its Strick");
        } else {
            output += rolls[i].ToString();                      // Normal 1-9 bowl
            Debug.LogError("Try Your Hard");
        }
    }
