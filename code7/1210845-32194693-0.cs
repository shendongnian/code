    public List<InputData> InputList = new List<InputData>();
    public void Builder()
    {    
       string input = Console.Readline();
       InputData id = new InputData(input);
       InputList.Add(id);
    }
