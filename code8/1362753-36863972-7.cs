    using System;
    using YourApplication.YourProject.Persistence;
    
    
    namespace YourApplication.YourProject
    {
      public class WorkHarness
      {
    
        public void Initialize()
        {
          DatabaseActions.dbFile = "your db file";
        }
    
        public void ShowMusicList()
        {
          // list the id and title so user can select by Id
          foreach (var music in DatabaseActions.ListMusic())
          {
            Console.WriteLine("{0,-10}{1}",music.Id,music.Title);
          }
        }
    
        public void DisplayMusicItem(int id)
        {
          var music = DatabaseActions.GetMusic(id);
    
          Console.WriteLine("Title: " + music.Title);
          Console.WriteLine("Length: " + music.Length);
          Console.WriteLine("Artist: " + music.Artist);
          Console.WriteLine("Album: " + music.Album);
        }
      }
    }
