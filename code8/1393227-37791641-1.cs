    if ( PersonalPolicy ) { }
    else { }
    if (FarmOwnersPolicy && !SelectomaticPolicy ) {
        //Will only be executed if FarmOwnersPolicy is True AND SelectomaticPolicy is NOT true.
    }
    if (!FarmOwnersPolicy && !SelectomaticPolicy) {
        // Will only be executed if FarmOwnersPolicy AND SelectomaticPolicy are both unset
    }
    if (!FarmOwnersPolicy || !SelectomaticPolicy) {
        // Will  be executed if either FarmOwnersPolicy OR SelectomaticPolicy is unset
    }
