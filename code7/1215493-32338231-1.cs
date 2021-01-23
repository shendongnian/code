    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
            }
        }
        [XmlRoot("PToolsConfiguration")]
        public class PToolsConfiguration 
        {
            [XmlElement("Database")]
            public Database db { get; set; }
            [XmlElement("Tools")]
            public Tools t { get; set; }
            [XmlElement("StaffManager")]
            public StaffManager sm { get; set; }
            [XmlElement("Loadout")]
            public Loadout l { get; set; }
            public PToolsConfiguration()
            {
                db = new Database();
                t = new Tools();
                sm = new StaffManager();
                l = new Loadout();
            }
            public void LoadDefaults()
            {
                db.DatabaseAddress = "localhost";
                db.DatabasePort = 3306;
                db.DatabaseName = "unturned";
                db.DatabaseTableName = "PTools";
                db.DatabaseUsername = "unturned";
                db.DatabasePassword = "password";
                t.EnableStaffManager = true;
                t.StaffManagerChatColor = "red";
                t.EnableServerSecurity = true;
                sm.EnableDutyAnnouncer = true;
                sm.RemoveAdminOnLogout = true;
                l.Items = new List<Item>() {
                        new Item() {
                            Id = 203,
                            Amt = 1
                        },
                        new Item() {
                            Id = 1015,
                            Amt = 1
                        },
                        new Item() {
                            Id = 1016,
                            Amt = 1
                        },
                        new Item() {
                            Id = 1017,
                            Amt = 3
                        },
                        new Item() {
                            Id = 333,
                            Amt = 3
                        },
                        new Item() {
                            Id = 93,
                            Amt = 3
                        },
                        new Item() {
                            Id = 466,
                            Amt = 2
                        },
                        new Item() {
                            Id = 151,
                            Amt = 1
                        },
                        new Item() {
                            Id = 345,
                            Amt = 1
                        },
                        new Item() {
                            Id = 347,
                            Amt = 15
                        },
                    };
                sm.Mods = new List<string>() { "76555555555551633"};
                        
                sm.Admins = new List<string>() {"76555555555551633"};
                      
            }
        }
        [XmlRoot("Database")]
        public class Database
        {
            [XmlElement("DatabaseAddress")]
            public string DatabaseAddress { get; set; }
            [XmlElement("DatabasePort")]
            public int DatabasePort { get; set; }
            [XmlElement("DatabaseName")]
            public string DatabaseName { get; set; }
            [XmlElement("DatabaseTableName")]
            public string DatabaseTableName { get; set; }
            [XmlElement("DatabaseUserName")]
            public string DatabaseUsername { get; set; }
            [XmlElement("DatabasePassword")]
            public string DatabasePassword { get; set; }
        }
        [XmlRoot("Tools")]
        public class Tools
        {
            [XmlElement("EnableStaffManager")]
            public bool EnableStaffManager { get; set; }
            [XmlElement("StaffManagerChatColor")]
            public string StaffManagerChatColor { get; set; }
            [XmlElement("EnableServerSecurity")]
            public bool EnableServerSecurity { get; set; }
        }
        [XmlRoot("StaffManager")]
        public class StaffManager
        {
            [XmlElement("EnableDutyAnnouncer")]
            public bool EnableDutyAnnouncer { get; set; }
            [XmlElement("RemoveAdminOnLogout")]
            public bool RemoveAdminOnLogout { get; set; }
            [XmlElement("Mods")]
            public List<string> Mods { get; set; }
            [XmlElement("Admins")]
            public List<string> Admins { get; set; }
        }
        [XmlRoot("Loadout")]
        public class Loadout
        {
            [XmlElement("Items")]
            public List<Item> Items { get; set; }
        }
        [XmlRoot("Item")]
        public class Item
        {
            [XmlElement("Id")]
            public int Id { get; set; }
            [XmlElement("Amt")]
            public Single Amt { get; set; }
        }
    }
    ​
