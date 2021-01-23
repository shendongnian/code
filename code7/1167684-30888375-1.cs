    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Kinect;
    
    namespace Coordinate_Mapper
    {
        class Program
        {
            public static KinectSensor ks;
            public static MultiSourceFrameReader msfr;
            public static Body[] bodies;
            public static CameraSpacePoint[] cameraSpacePoints;
            public static DepthSpacePoint[] depthSpacePoints;
            public static ColorSpacePoint[] colorSpacePoints;
    
            static void Main(string[] args)
            {
                ks = KinectSensor.GetDefault();
                ks.Open();
                bodies = new Body[ks.BodyFrameSource.BodyCount];
                cameraSpacePoints = new CameraSpacePoint[1];
                colorSpacePoints = new ColorSpacePoint[1];
                depthSpacePoints = new DepthSpacePoint[1];
                
                msfr = ks.OpenMultiSourceFrameReader(FrameSourceTypes.Depth | FrameSourceTypes.Color | FrameSourceTypes.Body);
                msfr.MultiSourceFrameArrived += msfr_MultiSourceFrameArrived;
    
                Console.ReadKey();
            }
    
            static void msfr_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
            {
                if (e.FrameReference == null) return;
                MultiSourceFrame multiframe = e.FrameReference.AcquireFrame();
                if (multiframe == null) return;
    
                if (multiframe.BodyFrameReference != null)
                {
                    using (var bf = multiframe.BodyFrameReference.AcquireFrame())
                    {
                        bf.GetAndRefreshBodyData(bodies);
                        foreach (var body in bodies)
                        {
                            if (!body.IsTracked) continue;
                            // CameraSpacePoint
                            cameraSpacePoints[0] = body.Joints[0].Position;
                            Console.WriteLine("{0} {1} {2}", cameraSpacePoints[0].X, cameraSpacePoints[0].Y, cameraSpacePoints[0].Z);
                            
                            // CameraSpacePoints => ColorSpacePoints
                            ks.CoordinateMapper.MapCameraPointsToColorSpace(cameraSpacePoints, colorSpacePoints);
                            Console.WriteLine("ColorSpacePoint : {0} {1}", colorSpacePoints[0].X, colorSpacePoints[0].Y);
                            
                            // CameraSpacePoints => DepthSpacePoints
                            ks.CoordinateMapper.MapCameraPointsToDepthSpace(cameraSpacePoints, depthSpacePoints);
                            Console.WriteLine("DepthSpacePoint : {0} {1}", depthSpacePoints[0].X, depthSpacePoints[0].Y);
                        }
                    }
                }
            }
        }
    }
