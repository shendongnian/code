    List<dynamic> Species = new List<dynamic>()
    {
        new { A = "1", CategoryId = 1 },
        new { A = "2", CategoryId = 2 },
    };
    List<dynamic> Categories = new List<dynamic>
    {
        new { B = "1", CategoryId = 1, GroupId = 1 },
        new { B = "2", CategoryId = 2, GroupId = 1 },
    };
    List<dynamic> Groups = new List<dynamic>
    {
        new { C = "1", GroupId = 1 }
    };
    //result: { Group: { C = "1", GroupId = 1 }, Categories (1,2)}
