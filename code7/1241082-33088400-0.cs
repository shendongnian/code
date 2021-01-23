    namespace CameraTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                int maxCam = 10,
                     maxChar = 33;
    
                var lst = (new object[maxCam]).Select(o => new string(' ', maxChar)).ToArray();
                bool sync = true;
                bool ret = CameraCalls.CAM_EnumCameraEx(sync, lst, maxCam, maxChar);
    
            }
        }
    
        public static class CameraCalls
        {
            [DllImport("CamDriver64.dll")]
            public static extern bool CAM_EnumCameraEx(bool sync,
                                                       [In, Out]
                                                       string[] lst, 
                                                       long maxCam, 
                                                       long maxChar);
        }
    }
