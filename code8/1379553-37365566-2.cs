    // I show just the TrafficLight class, but the same is true for the 
    // PedestrianLight class (better if both derives from the same base class)
    public class TrafficLight
    {
        private int counter = 0;
        public TrafficLightColor TrafficColor { get; set; }
        public int ID {get;set;}
        public int RedTime { get; set; }
        public int GreenTime { get; set; }
     
        public void SwitchLight(TrafficLightColor color)
        {
            if(color != TrafficColor)
            {
                TrafficColor = color;
                // Restart the counter everytime the color changes.....
                // So the next change happens for the current color.
                counter = 0;
            }
        }
        public void Tick()
        {
            if (this.TrafficColor == TrafficLightColor.RED && counter == RedTime)
                 SwitchLight(TrafficLightColor.GREEN);
            else if ((this.TrafficColor == TrafficLightColor.GREEN && counter == GreenTime)
                 SwitchLight(TrafficLightColor.RED);
        }
    }
