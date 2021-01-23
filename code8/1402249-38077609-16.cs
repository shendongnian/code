    public void Increment(int i) { i = i + 1; }
    
    var myInt = 1;
    Increment(myInt);
    Console.WriteLine(myInt); //Outputs 1, not 2. Why? i holds its own copy of 1, it knows nothing about the copy of 1 stored in myInt.
