csharp
using MongoDB.Driver;
using MongoDB.Entities;
using System;
namespace StackOverflow
{
    public class Program
    {
        public class Place : Entity
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public Coordinates2D Location { get; set; }
            public double DistanceMeters { get; set; }
        }
        static void Main(string[] args)
        {
            //connect to mongodb
            new DB("test");
            //create a geo2dsphere index
            DB.Index<Place>()
              .Key(x => x.Location, KeyType.Geo2DSphere)
              .Option(x => x.Background = false)
              .Create();
            //create and save a place
            var paris = new Place
            {
                Name = "paris",
                Location = new Coordinates2D(48.8539241, 2.2913515),
                Date = DateTime.UtcNow
            };
            paris.Save();
           
            var eiffelTower = new Coordinates2D(48.857908, 2.295243);
            //find all places within 1km of eiffel tower.
            var places = DB.GeoNear<Place>(
                              NearCoordinates: eiffelTower,
                              DistanceField: x => x.DistanceMeters,
                              MaxDistance: 1000)
                           .SortByDescending(x=>x.Date)
                           .ToList();
        }
    }
}
it generates the following aggregation pipeline:
java
{
                "$geoNear": {
                    "near": {
                        "type": "Point",
                        "coordinates": [
                            48.857908,
                            2.295243
                        ]
                    },
                    "distanceField": "DistanceMeters",
                    "spherical": true,
                    "maxDistance": NumberInt("1000")
                }
            },
            {
                "$sort": {
                    "Date": NumberInt("-1")
                }
            }
the above is done using [MongoDB.Entities](https://github.com/dj-nitehawk/MongoDB.Entities) convenience library, of which i'm the author of.
