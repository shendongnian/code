    public class Camera
    {
        [XmlElement]
        public long CameraId { get; set; }
        [XmlIgnore]
        public string Xml { get { return Extension.ToXmlString<Camera>(this); } }
    }
