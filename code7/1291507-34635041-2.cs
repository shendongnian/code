    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Pirate> pirates = new List<Pirate>() {
                        new Pirate() { id = "1" , Ships = new List<Ship>(){
                            new Ship() { name = "Maria", _class = "BattleShip", avastyemast = "You Sunk My Battleship"},
                            new Ship() { name = "Clara", _class = "Scout", avastyemast = "You Sunk My Battleship"}
                        }
                    },
                        new Pirate() { id = "2" , Ships =  new List<Ship>() {
                            new Ship() { name = "Boon", _class = "Sub", avastyemast = "You Sunk My Battleship"},
                            new Ship() { name = "Slimer", _class = "Scout", avastyemast = "You Sunk My Battleship"}
                        }
                    }
                };
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("class", typeof(string));
                dt.Columns.Add("avastyemast", typeof(string));
                foreach (Pirate pirate in pirates)
                {
                    foreach(Ship ship in pirate.Ships)
                    {
                        dt.Rows.Add(new string[] {
                            pirate.id,
                            ship.name,
                            ship._class,
                            ship.avastyemast
                        });
                    }
                }
                //using linq
               var newRows = pirates.Select(x => x.Ships.Select(y => new List<object>() {x.id, y.name, y._class, y.avastyemast})).SelectMany(z => z).ToList();
               foreach (var row in newRows)
               {
                   dt.Rows.Add(row);
               }
            }
        }
        public class Pirate
        {
            public string id {get;set;} 
            public List<Ship> Ships {get;set;}
        }
        public class Ship
        {
            public string name {get;set;}
            public string _class {get;set;}
            public string avastyemast {get;set;}
        }
    }
    ​
