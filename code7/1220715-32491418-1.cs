    enum Vehicle1
        {
            None = 0,
            Bicycle = 1,
            //Motorcycle = 2,
            //Car = 3,
            //Van = 4,
            //Lorry = 5,
            //Aeroplane = 6,
            //Rocket = 7,
            //TimeMachine = 8,
    
            Basikal = Bicycle,//set to 1
            Fahrrad = Basikal, // also set to 1
            Velo = 2, // this is explictitly set as 2, becuase of the commented items above, otherwise the auto index would be 9
        }
