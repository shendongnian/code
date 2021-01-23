    void nextItem() {
        index++; // increment index
        index %= items.Count; // clip index (turns to 0 if index == items.Count)
        // as a one-liner:
        /* index = (index + 1) % items.Count; */
        setItem();
    }
    
    void previousItem() {
        index--; // decrement index
        if(index < 0) {
            index = items.Count - 1; // clip index (sadly, % cannot be used here, because it is NOT a modulus operator)
        }
        // or above code as a one-liner:
        /* index = (items.Count+index-1)%items.Count; */ // (credits to Matthew Watson)
        setItem();
    }
