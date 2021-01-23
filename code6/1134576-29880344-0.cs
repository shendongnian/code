    class Composer
    {
       public Composer( string lastName, string firstName, int year, int month )
       {
          LastName = lastName;
          FirstName = firstName;
          YearOfBirth = year;
          MonthOfBirth = month;
       }
       public string LastName { get; set; }
       public string FirstName { get; set; }
       public int YearOfBirth { get; set; }
       public int MonthOfBirth { get; set; }
       public override string ToString()
       {
           return string.Format( "{0} {1} {2} {3}", LastName, FirstName, YearOfBirth.ToString(), MonthOfBirth.ToString() );
       }
    }
    
    
    class Program
    {
       private static new List<Composer> composerList = new List<Composer>();
    
       static void Main( string[] args )
       {
          composerList.Add( new Composer( "Mozart", "Wolfgang", 1756, 1 ) );
          composerList.Add( new Composer( "Vivaldi", "Antonio", 1678, 3 ) );
    
          Console.WriteLine( "Please enter a name you want to search for!" );
          string name = Console.ReadLine();
          ShowComposerData( name );
       }
    
    
       private static void ShowComposerData( string name )
       {
          foreach( Composer comp in composerList )
          {
             if( comp.LastName == name )
             {
                Console.WriteLine( comp.ToString() );
             }
          }
       }
    }
