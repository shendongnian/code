     public   void displayZooPopulation() 
        {
            foreach (var a in animals)
            {
                if ( a is Fish)
                {
    //here sure "a" is not null, no need to check against null
                    var fish = a as Fish;
                    //  if (a.species == "fish" && (Fish) a.CanSplash)
                    if ( fish.CanSplash)
                    {
                        Console.WriteLine("{0} can splash", a.Name);
                    }
                }
            }
        }
