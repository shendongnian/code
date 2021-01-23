    int _numbers = int.Parse(Console.ReadLine());// Get number of ints to calculate
        int[] _numbersToProcess = new int[_numbers];// Array of inputs
        int[] _result = new int[_numbers];
        int i = 0;
        while(i < _numbersToProcess.Length) {
            _numbersToProcess[i] = int.Parse(Console.ReadLine());
            i++;
        }
        for (int x = 0; x < _numbersToProcess.Length; x++)
            {// Loop throuigh Array by index
                int fact = 1;
                for (int y = 1; y <= _numbersToProcess[x]; y++)
                {// Y is equal to less than index x
                    fact = fact*y;
                }
                _result[x] = fact;
            }
        for (int n = 0; n < _result.Length; n++) {// Y is equal to less than index x
            Console.WriteLine(_result[n]);// Write to console
        }
        Console.ReadLine();
