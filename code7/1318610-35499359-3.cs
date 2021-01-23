    int[] pizzaSlices = new int[4] { 8, 12, 16, 24 };
    int[] pizzaDims = new int[4] { 12, 21, 25, 31 }; // pizza diameters array
    
    if(inputDiameter >= smallest) {
        for (int i = 0; i <= pizzaSlices.Length; i++) {
            if(inputDiameter >= pizzaDims[i] {
                Console.WriteLine("cut in " + pizzaSlices[i] + 
                                  " slices results in a slice area of " +
                                  Math.Round(areaOfThePizza / pizzaSlices[i], 2) +
                                  " per slices");
            } else {
                break; // no need to continue iterating, if one condition is false then
                       // the rest will be as well
            }
        }
    }
