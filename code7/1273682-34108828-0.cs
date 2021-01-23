    IEnumerable<int> Squares()
    {
        for (var i = 1; i < Int32.MaxValue; i++)
        {
            yield return i * i; 
        }
    }
    // ... usage
    Squares().Take(5); // Gets the first five squares, execution state of 
                       // of Squares() is kept in a state machine the 
                       // compiler creates for you behind the scenes. 
    Sqaures().Take(5); // Gets the next five squares. 
