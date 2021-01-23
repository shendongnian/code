    static void Main(string[] args)
    {
        dynamic dObject = JObject.Parse(json);
                         
        Console.WriteLine(dObject.VisitingTeamFootballRbStats[0].AthleteLastName); 
        //Prints "John"
    
        Console.ReadLine();
    }
    
    private static string json = @"
        {
            'InputKoffRetStats':true,'InputPenaltyStats':false,
            'VisitingTeamFootballRbStats':
            [{
                'AthleteLastName':'John',
                'AthleteFirstName':'Smith','Number':9,'IsPresent':true
            },
            {
                'AthleteLastName':'Justin',
                'AthleteFirstName':'Brooks','Number':10,'IsPresent':false
            }]
        }
        ";
