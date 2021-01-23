    int[] pizzaSlices = new int[4] { 8, 12, 16, 24 };
    int[] pizzaDims = new int[4] { 20, 24, 30, 36 }; // pizza diameters array
    int smallest = 12;
    
    if(inputDiameter >= smallest) {
        for (int i = 0; i <= pizzaSlices.Length; i++) {
            if(inputDiameter >= pizzaDims[i] {
                Console.WriteLine("cut in " + pizzaSlices[i] + 
                                  " slices results in a slice area of " +
                                  Math.Round(areaOfThePizza / pizzaSlices[i], 2) +
                                  " per slices");
            }
        }
    }
