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
                List<Pirate> pirates = new List<Pirate>();
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
