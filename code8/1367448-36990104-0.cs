    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        public class Point2D
        {
            public Point2D()
            {
                X = double.NaN;
                Y = double.NaN;
            }
    
            public Point2D(double xValue, double yValue)
            {
                X = xValue;
                Y = yValue;
            }
    
            public double X { get; set; }
            public double Y { get; set; }
        }
    
        public class CameraCalibration2D
        {
    
            private Point2D _GridOffset = new Point2D(0, 0);
            public Point2D GridOffset
            {
                get { return _GridOffset; }
                set { _GridOffset = value; }
            }
        }
    
        public class LaserLineProfiler 
        {
            public LaserLineProfiler()
            {
    
            }
    
            private CameraCalibration2D _Calibration2D = new CameraCalibration2D();
            public CameraCalibration2D Calibration2D
            {
                get { return _Calibration2D; }
                set { _Calibration2D = value; }
            }
    
            private Point2D _Scale = new Point2D(0, 0);
            [IgnoreDataMember]    
            public Point2D Scale 
            { 
                get{return _Scale;} 
                set{_Scale = value;} 
            }
    
            public partial class PageDeviceEditor
            {
    
                static LaserLineProfiler m_CaptureDevice = new LaserLineProfiler() ;
                public PageDeviceEditor()
                {
            
                }
    
                static void Main(string[] args)
                {
                    Console.WriteLine(SerializeCalDataObject.ToXML(m_CaptureDevice));
                    Console.ReadLine();
                }
            }
        }
    
        public static class SerializeCalDataObject
        {
            public static XElement ToXML(this object o)
            {
                Type t = o.GetType();
    
                DataContractSerializer serializer = new DataContractSerializer(t);
                StringWriter sw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(sw);
                serializer.WriteObject(xw, o);
                return XElement.Parse(sw.ToString());
            }
        }
    }
