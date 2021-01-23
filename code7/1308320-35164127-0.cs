    string vTempLine;    // Not needed to be declared outside the loop
    int i = 0;
    int vCountLoop1 = 0; // Not needed: Might be the same as i
    Dictionary<int, string> vFile1Array = new Dictionary<int, string>(); // Or use a List<string>
    
    using (StreamReader sr = new StreamReader("File1.txt")) 
    {
        while (sr.Peek() >= 0) 
        {
            // if statement is not needed here
            i++;
            vTempLine = sr.ReadLine();
            vCountLoop1 = i;
            vFile1Array[i] = vTempLine; 
        }
    }
