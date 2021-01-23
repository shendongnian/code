    var room = new Room
            {
                id = "new room",
                name = "very cool room",
                description = "A very cool room that was added on the fly",
                items = new List<Item> 
                            { 
                              new Item 
                                   { 
                                     id = "another sword", 
                                     description = "Another battered sword"
                                     //etc...
                                    } 
                              }
                //etc...
            }
    game.Rooms.Add(room);
