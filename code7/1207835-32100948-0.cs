    Class MovieRating
    {
      public int RateActing { get; set; }
      public int RateMusic { get; set; }
      public int RateDuratn { get; set; }
  
        public void DetailsRate()
        {
            Console.WriteLine("\n Rate the Acting on a scale of 0 to 5");
             RateActing = int.Parse(Console.ReadLine());
    
            Console.WriteLine("\n Rate the music of the movie on a scale of 0 to 5");
            RateMusic = int.Parse(Console.ReadLine());
    
            Console.WriteLine("Rate the cinematography of the movie on a scale of 0 to 5");
    
            Console.WriteLine("Rate the plot of the movie on a scale of 0 to 5");
            Console.WriteLine("Rate the duration of the movie on a scale of 0 to 5");
            RateDuratn = int.Parse(Console.ReadLine());
    
        }
    }
