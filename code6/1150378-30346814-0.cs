    // Declare and initialize variables
    List<int> MyList = new List<int>();
    Random r = new Random();
    int LoopJumps = r.Next(2,30);
    MyList.AddRange(Enumerable.Range(0, r.Next(1, 100));
    // the loop code
    for(int i=0; i < MyList.Count; i+= LoopJumps) {
        if(i >= MyList.Count) break;
        // Do your thing...
    }
