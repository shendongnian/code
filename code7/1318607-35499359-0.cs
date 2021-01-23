    int[] pizzaSlices = new int[4] { 8, 12, 16, 24 };
    int[] pizzaDims = new int[8] { 12, 20, 21, 24, 25, 30, 31, 36 };
    
    for (int i = 0; i <= pizzaSlices.Length; i++) {
        if(inputDiameter >= pizzaDims[i*2] && inputDiameter <= pizzaDims[i*2 + 1]) {
            Console.WriteLine("cut in " + pizzaSlices[i] + " slices results in a slice area of "
                              + Math.Round(areaOfThePizza / pizzaSlices[i], 2) + " per slices");
        }
    }
