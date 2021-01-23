    // You must declare aliases here:
    extern alias KinectV1;
    extern alias KinectV2;
    // Then some using...
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    // ... and do not forget Kinect!
    using KinectV1;
    using KinectV2;
    // Now you can do something like this:
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Something from Microsft.Kinect V2
                KinectV2.Microsoft.Kinect.HandState hs = KinectV2.Microsoft.Kinect.HandState.Closed;
                // Something from Microsft.Kinect V1
                KinectV1.Microsoft.Kinect.Skeleton s = new KinectV1.Microsoft.Kinect.Skeleton();
            }
        }
    }
