    using (var logger = new StreamWriter(new FileStream("data.txt", FileMode.OpenOrCreate), Encoding.UTF8))
    {
        var game = new Game();
        game.GameStarted += (sender, eventArgs) => logger.WriteLine("PositionRingFeeback" + "," + "PositionSphereMiddle" + "," + "distanceRingFeedbackTOSphere" + "," + "Collisions" + "," + "Timer");
        game.GameEvent += (sender, data) => logger.Write("{0}{1}{2}{3}{4}", data.PositionRingFeeback, data.PositionSphereMiddle, data.DistanceRingFeedbackToSphere, data.Collisions, data.Timer);
        game.Start();
    }
 
