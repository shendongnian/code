    // Serialize array to a string
    int[] vals = new int[] { 1, 2, 3, 4, 5 };
    string valsArgument = JsonConvert.SerializeObject(vals); // "[1,2,3,4,5]"
    // In your target application
    int[] vals = JsonConvert.DeserializeObject<int[]>(argument1);
