    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Actor
        {
            public string Title { get; set; }
            public List<string> Actors { get; set; }
            public override string ToString()
            {
                return $"{Title} featuring {string.Join(", ", Actors)}";
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<Actor> movies = new List<Actor>()
                {
                    new Actor() { Title = "Star Wars", Actors = new List<string>() {  "Mark Hamill", "Harrison Ford" } },
                    new Actor() { Title = "Indiana Jones and The Raiders of the Lost Ark", Actors = new List<string>() {  "Karen Allen", "Harrison Ford" } },
                    new Actor() { Title = "Indiana Jones and The Temple of Doom", Actors = new List<string>() {  "Kate Kapshaw", "Harrison Ford" } },
                    new Actor() { Title = "Indiana Jones and The Kingdom of the Crystal Skull", Actors = new List<string>() {  "Cate Blanchett", "Harrison Ford" } },
                    new Actor() { Title = "Jessica Jones", Actors = new List<string>() {  "Krysten Riter", "David Tennant" } },
                    new Actor() { Title = "The Wizard of Oz", Actors = new List<string>() {  "Judy Garland" } },
                };
    
                var list = movies.Where(x => x.Title.Contains("Jones")).Union(movies.Where(x => x.Actors.Contains("Harrison")));
    
                var pagedList = list.ToPagedList(1, 2);
    
                foreach (var movie in pagedList)
                {
                    Console.WriteLine(movie);
                }
            }
        }
    }
