    IEnumerable<char> inArArray = ar.Except(ay);
    foreach (char c in inArArray) {
                 Console.WriteLine("{0} Exists in ar but not in ay",c);
    }
        
     
    IEnumerable<char> inAyrray = ay.Except(ar);
    foreach (char c in inAyrray)
    {
                    Console.WriteLine("{0} Exists in ay but not in ar", c);
    }
