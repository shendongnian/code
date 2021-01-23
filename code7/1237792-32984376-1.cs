    public class Dog
    {
 
      bool _isRunning = true;
      Point Location { get; set; }
 
      Point NextLocation { get; set; }
      PictureBox PictureBoxDog { get; set; }
      public Dog(PictureBox pictureBox) 
      {
         PictureBoxDog = pictureBox;
         Location = GetRandomLocation();
         
         NextLocation = GetRandomLocation();
      }
      private Point GetRandomLocation()
      {
         var random = new Random();
         return new Point(random.Next(800), random.Next(800));
      }
      public void Update()
      {
        if (NextLocation.X == Location.X && NextLocation.Y == Location.Y)
        {
          NextLocation = GetRandomLocation();
        }
        if (_isRunning)
        {
           var dx = Math.Sign(NextLocation.X - Location.X);
           var dy = Math.Sign(NextLocation.Y - Location.Y);
           Location = new Point(Location.X + dx, Location.Y + dy);
        }
      }
      public void Draw()
      {
         PictureBoxDog.Location = Location;
      }
    }
