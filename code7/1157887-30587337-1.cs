    class Program
    {
        static void Main(string[] args)
        {
            var cam = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice).First();
            var grabber = new FrameGrabber(cam);
            Console.ReadLine();
        }
    }
