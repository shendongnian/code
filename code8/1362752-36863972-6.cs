    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using YourApplication.YourProject.Models;
    
    namespace YourApplication.YourProject.Persistence
    {
      public static class DatabaseActions
      {
        public static string dbFile;
    
        public static Music[] ListMusic()
        {
          var musicList = new List<Music>();
    
          // database call to get all music
          using (var connection = new SQLiteConnection(dbFile))
          {
            connection.Open();
            using (var command = new SQLiteCommand("spGetMusic", connection))
            {
              var reader = command.ExecuteReader();
    
              // The try finally blocks are not strictly needed as these will are suppose to be called upon disposal
              try
              {
                // loop through records creating music objects
                while (reader.Read())
                {
                  var music = new Music();
                  music.Id = reader.GetInt32(0);
                  music.Title = reader.GetString(1);
                  musicList.Add(music);
                }
              }
              finally
              {
                reader.Close();
                connection.Close();
              }
            }
          }
          return musicList.ToArray();
        }
    
        public static int SaveMusic(Music music)
        {
          if (music.Id == 0)
          {
            // database stuff - getting the newly created database id  
          }
          else
          {
            // database calls to update record
          }
    
          return music.Id;
        }
    
        public static int SaveFilm(Film film)
        {
          if (film.Id == 0)
          {
            // database stuff - getting the newly created database id  
          }
          else
          {
            // database calls to update record
          }
    
          return film.Id;
        }
    
    
        public static Music GetMusic(int id)
        {
          var music = new Music();
    
          // database call and setting of values on music
    
          return music;
        }
    
    
        public static Film GetFilm(int id)
        {
          var film = new Film();
    
          // database call and setting of values on music
    
          return film;
        }
    
      }
    }
