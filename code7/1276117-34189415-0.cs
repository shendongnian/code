    public class Program
    {
        static InterruptPort hazardButton = new InterruptPort(Pins.GPIO_PIN_D0, false, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeBoth);
        static OutputPort hazardLights = new OutputPort(Pins.ONBOARD_LED, false);
        static volatile bool hazardsActive = false;
        public static void Main()
        {
            Debug.Print("Initializing Inputs... ");
            hazardButton.OnInterrupt += new NativeEventHandler(hazardButton_OnInterrupt);
            bool lightOn = true;
            while (true)
            {
                if (!hazardsActive)
                {
                    hazardLights.Write(false);
                }
                else
                {
                    hazardLights.Write(lightOn);
                    lightOn = !lightOn;
                }
                Thread.Sleep(500);
            }
        }
        static void hazardButton_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            hazardsActive = !hazardsActive;
        }
    }
