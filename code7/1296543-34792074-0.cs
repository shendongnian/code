    // My ClassName with method Hours()
    public static double Hours() { //return double here
        var citiesDistance = new Dictionary<string, int> { 
            {"Place1",10},
            {"Place2",20},
            {"Place3",30},
        };
        var cities = "Place1";
        double length = citiesDistance[cities]; //use double
        double speed = 100; //use double
        double hours = length / speed; //use double
        return hours; //note that it is returned
    }
