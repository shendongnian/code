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
        // Calculates the new coordinates for a dog
        // The dog starts from a random position, and is 
        // given a new random position to run towards.
        // If the dog has arrived at the new random position, then
        // give the dog a new random position to run to again
        if (NextLocation.X == Location.X && NextLocation.Y == Location.Y)
        {
          NextLocation = GetRandomLocation();
        }
        if (_isRunning)
        {
           // Move the dog closer to its destination
           // dx and dy can be -1, 0, or 1
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
