    List<string> stringArray = File.ReadAllLines(@"filePath").ToList();
    List<int> intList= stringArray.Select(x => x!=null || x!="" ?0:int.Parse(x)).ToList(); 
    //Now `intList` will be the list of integers, you can process with them;
    int resistance=intArray[0];
    for (int i = 1; i < intArray.Count ; i++)
    {
      resistor[i] = new Resistors(intArray[i], resistance);
    }
