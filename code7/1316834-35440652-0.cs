    List<int> ratingsList = new List<int>(); //Presume this is already populated.
    List<int> team1 = new List<int>();
    List<int> team2 = new List<int>();
    
    ratingsList = ratingsList.Sort();
    
    if(ratingsList.Count() % 2 != 0)
    {
        ratingsList.Remove((ratingsList.Count()/2)+2));  //Integer divide intentional
    }
    
    for(int i = 0; i < ratingsList.Count() ; i++)
    {
        if(i%2 != 0)
        {
            team1.Add(ratingsList[i]);
        }
        else
        {
            team2.Add(ratingsList[i]);
        }
    }
    
    foreach(var player in team1)
    {
        //Add SQL Insert here
    }
    foreach(var player in team2)
    {
        //Add SQL Insert here
    }
