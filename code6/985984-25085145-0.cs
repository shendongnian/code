        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Xml.Serialization;
    
    namespace XmlTypes
    {
      public class SvgStyle : IXmlSerializable
      {
    
        private const string fillColorKey = "fill";
        private const string strokeColorKey ="stroke";
        private const string strokeWidthKey = "stroke-width";
        private const string strokeMiterLimitKey = "stroke-miterlimit";
        private const string strokeOpacityKey ="stroke-opacity";
        private const string strokeDashArrayKey="stroke-dasharray";
        private const string strokeDashOffsetKey = "stroke-dashoffset";
        
        [XmlAttribute]
        public String Style { get; set; }
        public string FillColor { get; set; }
        public string StrokeColor { get; set; }
        public float StrokeWidth { get; set; }
        public int StrokeMiterlimit { get; set; }
        public float StrokeOpacity { get; set; }
        public float StrokeDashoffset { get; set; }
        public string StrokeDasharray { get; set; }
        
    
        public System.Xml.Schema.XmlSchema GetSchema()
        {
          return null;
        }
    
        public void ReadXml(System.Xml.XmlReader reader)
        {
          reader.MoveToContent();
          Style = reader.GetAttribute("style");
          Dictionary<string, string> lookupTable = ParseAttribute(Style);
    
          FillColor = lookupTable[fillColorKey];
          StrokeColor = lookupTable[strokeColorKey];
          
          float strokeWidthFloatValue=0; 
          float.TryParse(lookupTable[strokeWidthKey] , out strokeWidthFloatValue) ;
          StrokeWidth = strokeWidthFloatValue;
          
          int strokeMiterLimitInt = 0;
          Int32.TryParse(lookupTable[strokeMiterLimitKey] , out strokeMiterLimitInt);
          StrokeMiterlimit = strokeMiterLimitInt;
    
          int strokeOpacityInt = 0;
          Int32.TryParse(lookupTable[strokeMiterLimitKey], out strokeOpacityInt);
          StrokeOpacity = strokeOpacityInt;
    
          int strokeDashOffsetInt = 0;
          Int32.TryParse(lookupTable[strokeMiterLimitKey], out strokeDashOffsetInt);
          StrokeDashoffset = strokeDashOffsetInt;
          
          StrokeDasharray = lookupTable[strokeDashArrayKey];
    
    
          Boolean isEmptyElement = reader.IsEmptyElement; // (1)
          reader.ReadStartElement();
     
        }
    
        public void WriteXml(System.Xml.XmlWriter writer)
        {
          writer.WriteAttributeString("style", Style);
       
        }
        private Dictionary<string, string> ParseAttribute(string attribute)
        {
          string[] arr = attribute.Split(';');
          Dictionary<string, string> dic = new Dictionary<string, string>();
          for(int i = 0; i < arr.Length; i++)
          {
            string[] arrItem = arr[i].Split(':');
            dic.Add(arrItem[0], arrItem[1]);
          }
          return dic;
        }    
      }
    }
   
     [TestMethod]
        public void TestMethod1()
        {
          string xml = @"<SvgStyle style='fill:none;stroke:#00ff00;stroke-width:8.7489996;stroke-miterlimit:4;stroke-opacity:1;stroke-dasharray:none;stroke-dashoffset:8.74900006'></SvgStyle>";
    
          XmlSerializer x = new XmlSerializer(typeof(SvgStyle));
          SvgStyle myTest = (SvgStyle)x.Deserialize(new StringReader(xml));
    
        }
