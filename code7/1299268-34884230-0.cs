    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication70
    {
        class Program
        {
            static void Main(string[] args)
            {
                AutoBody bodies = new AutoBody()
                {
                   vehicles = new List<Vehicles>()
                    {
                        new Vehicles() {
                            SelectedCar = new SelectedCar() { Model = "Ford", NumTires = 1, Color = "red"}
                        },
                        new Vehicles() {
                            SelectedCar = new SelectedCar() { Model = "Chevy", NumTires = 2, Color = "blue"}
                        },
                        new Vehicles() {
                            SelectedCar = new SelectedCar() { Model = "Jeep", NumTires = 3, Color = "green"}
                        },
                        new Vehicles() {
                            SelectedCar = new SelectedCar() { Model = "Merecedes", NumTires = 4, Color = "red"}
                        },
                    }
                };
                List<string> colors = bodies.vehicles.Select(x => x.SelectedCar).Select(y => y.Color).Distinct().ToList();
               
            }
        }
        [Serializable()]
        [System.Xml.Serialization.XmlRoot("AutoEnvelope")]
        public class AutoBody
        {
            [XmlArray("AutoBody")]
            [XmlArrayItem("Vehicles", typeof(Vehicles))]
            public List<Vehicles> vehicles { get; set; }
        }
        [Serializable()]
        public class Vehicles
        {
            [XmlElement("SelectedCar", typeof(SelectedCar))]
            public SelectedCar SelectedCar { get; set; }
            //[XmlElement("OfferedVehicles", typeof(OfferedVehicles))]
            //public OfferedVehicles OfferedVehicles { get; set; }
        }
        [Serializable()]
        public class SelectedCar
        {
            [System.Xml.Serialization.XmlElement("Model")]
            public string Model { get; set; }
            [System.Xml.Serialization.XmlElement("NumTires")]
            public int NumTires { get; set; }
            [System.Xml.Serialization.XmlElement("Color")]
            public string Color { get; set; }
        }
    }
