    string input = "100000"; //your textbox input
    int[] digits = new int[] { 3, 2, 1 }; // the digits to repeat
    int[] numberB = new int[input.Length]; // the number componsed of 3, 2, 1, ...
            
    //numberB creation
    int index = 0;
    for (int i = 0; i < numberB.Length; ++i)
    {
        numberB[i] = digits[index];
        ++index;
        if (index >= 3)
        {
            index = 0;
        }
    }
    int[] numberA = input.ToCharArray().Select(a => int.Parse(a.ToString())).ToArray(); // the input "number"
    //multiplication
    int[] output = new int[input.Length];
    for (int i = 0; i < output.Length; ++i)
    {
        output[i] = numberA[i] * numberB[i];
    }
