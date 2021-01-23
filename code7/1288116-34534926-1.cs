    var controllers = new[] {
        new Controller()
        {
            Name = "Test1",
            Actions = new Action[] {
                new Action { Name = "Action1", HttpCache = 300 },
                new Action { Name = "Action2", HttpCache = 200 },
                new Action { Name = "Action3", HttpCache = 400 },
            }
        },
        new Controller()
        {
            Name = "Test2",
            Actions = new Action[] {
                new Action { Name = "Action1", HttpCache = 300 },
                new Action { Name = "Action2", HttpCache = 200 },
                new Action { Name = "Action3", HttpCache = 400 },
            }
        },
    };
