    string[] stringArray = CMath.CharArrayToStringArray(getName().ToCharArray());
    string randChar = getName().ToCharArray()[(CMath.randomIntBetween(0, getName().Length - 1))].ToString();
    string removedLetter = String.Emty;
    
    //create chars, if the char is the random character, skip its creation and store it to create it later on the place where the child can drag the words.
    for (int i = 0; i < getName().Length; i++)
    {
     if (stringArray[i] != randChar || !String.IsNullOrEmpty(removedLetter))
    {
     CCharacter aChar = new CCharacter(stringArray[i], (110) + 100 * i, 750, CCharacter.TYPE_GREEN);
     aChar.setInactive(true);
     mCharList.Add(aChar);
    }
    else
    {
      removedLetter =  stringArray[i];
     }
    }
