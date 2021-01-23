    List<TeamNRegion> teamRegionList = new List<TeamNRegion>()
                                      {
                                        new  TeamNRegion(){Id=1,TeamName="Fnatic",RegionName="Europe"}, 
                                        new  TeamNRegion(){Id=10,TeamName="SKT T1",RegionName="Korea"},
                                        new  TeamNRegion(){Id=11,TeamName="Flash Wolves",RegionName="Taiwan"},
                                        new  TeamNRegion(){Id=12,TeamName="EDG",RegionName="China"},
                                      };
    
    // Print the result like this
    
    foreach (TeamNRegion team in teamRegionList)
    {
        Console.WriteLine(team.ToString());
    }
  
