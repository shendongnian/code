    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Film> films = new List<Film>() {
                    new Film() {
                        Title = "Terminator",
                        Actors = new List<string>() {
                            "Arnold Schwarzenegger",
                            "Michael Biehn",
                            "Linda Hamilton"
                        }
                    },
                    new Film() {
                        Title = "Aliens",
                        Actors = new List<string>() {
                            "Sigourney Weaver",
                            "Carrie Henn",
                            "Michael Biehn"
                        }
                    },
                    new Film() {
                        Title = "Avatar",
                        Actors = new List<string>() {
                            "Sam Worthington",
                            "Zoe Saldana",
                            "Sigourney Weaver"
                        }
                    },
                    new Film() {
                        Title = "Star Wars",
                        Actors = new List<string>() {
                            "Mark Hamill",
                            "Harrison Ford",
                            "Carrie Fisher"
                        }
                    }
                };
    
                var filmIndex = films.ToDictionary(
                    f => f.Title, 
                    m => films
                        .Where(f => f.Title != m.Title && 
                            f.Actors
                            .Intersect(m.Actors)
                            .Any())
                            .Select(t => t.Title));
    
                foreach (var film in filmIndex)
                {
                    Console.WriteLine(string.Format("Movie: {0} has same actors as {1}.", 
                        film.Key, 
                        film.Value.Any() ? film.Value.Aggregate((i, j) => i + ", " + j) : "no other film"));
                }
    
                Console.ReadKey();
            }
        }
    
        class Film
        {
            public string Title { get; set; }
            public IEnumerable<string> Actors { get; set; }
        }
    }
