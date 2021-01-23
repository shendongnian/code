    EnumType[] Vowels = new [] {EnumType.A, EnumType.E, EnumType.I, EnumType.O, EnumType.U};
    if (someEnum == EnumType.A)
    	SomeMethodSpecificToA();
    
    if (new [] {EnumType.B, EnumType.C, EnumType.D}.Contains(someEnum))
    	SomeMethodSpecificToTheseThreeLetters();
    
    if (someEnum == EnumType.E)
    	SomeMethodSpecificToE();
    
    if (Vowels.Contains(someEnum))
    	AMethodIShouldCallOnAllVowels();
