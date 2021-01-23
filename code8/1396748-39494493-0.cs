    // Declare some testing data
    int[][] inputs = new int[][]
    {
        new int[] { 0,1,1,0 },   // Class 0
        new int[] { 0,0,1,0 },   // Class 0
        new int[] { 0,1,1,1,0 }, // Class 0
        new int[] { 0,1,0 },     // Class 0
    
        new int[] { 1,0,0,1 },   // Class 1
        new int[] { 1,1,0,1 },   // Class 1
        new int[] { 1,0,0,0,1 }, // Class 1
        new int[] { 1,0,1 },     // Class 1
    };
    
    int[] outputs = new int[]
    {
        0,0,0,0, // First four sequences are of class 0
        1,1,1,1, // Last four sequences are of class 1
    };
    
    
    // We are trying to predict two different classes
    int classes = 2;
    
    // Each sequence may have up to two symbols (0 or 1)
    int symbols = 2;
    
