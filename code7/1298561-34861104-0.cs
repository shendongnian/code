    [XmlRoot("ArrayOfSimulatedRailCar")]
    public class SimulatedTrain
    {
        [XmlElement("SimulatedRailCar")]
        public List<SimulatedRailCar> Cars { get; set; }
    }
