    int seed = 0;
    if(categorySeeds.HasKey(categoryName))
    {
       seed = categorySeeds[categoryName];
    }
    else
    {
       seed = (int)DateTime.Now.Ticks % 9395713;//a random number
       categorySeeds.Add(categoryName, seed);
    }
    //rest of the code
   
