    using System;
    using System.Collections.Generic;
    
    class Cd
    {
      public string Name { get; set; }
      public string Artist { get; set; }
      public string Genre { get; set; }
      public List<string> Tracklist { get; set; }
      public Cd()
      {
         Name = "CD Name";
         Artist = "CD Artist";
         Genre = "CD Genre";
         Tracklist = new List<string>();
      }
      public string getTracklist()
      {
         return String.Join(", ", Tracklist);
      }
    }
    
    public class Exercise2
    {
      public static void Main()
      {
         Cd CD1 = new Cd();
         CD1.Name = "Kill 'Em All";
         CD1.Artist = "Metallica";
         CD1.Genre = "Thrash Metal";
         CD1.Tracklist.Add("Hit the Lights");
         CD1.Tracklist.Add("The Four Horsemen");
         CD1.Tracklist.Add("Motorbreath");
         Cd CD2 = new Cd();
         CD2.Name = "Ride The Lightning";
         CD2.Artist = "Metallica";
         CD2.Genre = "Thrash Metal";
         Cd CD3 = new Cd();
         CD3.Name = "Master Of Puppets";
         CD3.Artist = "Metallica";
         CD3.Genre = "Thrash Metal";
         Console.WriteLine(CD1.Name + " - " + CD1.Artist + " - " + CD1.Genre + " - " + CD1.getTracklist());
         Console.WriteLine(CD2.Name + " - " + CD2.Artist + " - " + CD2.Genre);
         Console.WriteLine(CD3.Name + " - " + CD3.Artist + " - " + CD3.Genre);
      }
    }
