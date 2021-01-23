csharp
using System.Linq;
using MongoDB.Entities;
namespace StackOverflow
{
    public class Person : Entity
    {
        public string Username { get; set; }
        public Many<Follower> FollowerList { get; set; }
        public Person() => this.InitOneToMany(() => FollowerList);
    }
    public class Follower : Entity
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new DB("followers");
            var person1 = new Person { Username = "bodrum"};
            person1.Save();
            var follower1 = new Follower { Name = "fethiye", Avatar= "fethiye.png" };
            follower1.Save();
            var follower2 = new Follower { Name = "izmir", Avatar = "izmir.png" };
            follower2.Save();
            person1.FollowerList.Add(follower1);
            person1.FollowerList.Add(follower2);
            var fathiye = person1.FollowerList.Collection()
                                              .Where(p => p.Name == "fethiye")
                                              .FirstOrDefault();
            person1.FollowerList.Remove(fathiye);
        }
    }
}
