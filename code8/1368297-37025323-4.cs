    [XmlRoot(ElementName = "test")]
    public class test
    {
        [XmlElement(ElementName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        public Details Details { get; set; }
        [XmlElement(ElementName = "Remark")]
        public Remark Remark { get; set; }
    
        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
    
            // modify the code below to suit your needs...
            test objA = (test) obj;
            return this.ID == objA.ID && this.Name == objA.Name
                && this.Details.duration == objA.Details.duration && this.Details.time == objA.Details.time
                && this.Remark.IsRemarkVisible == objA.Remark.IsRemarkVisible && this.Remark.RemarkText == objA.Remark.RemarkText; 
        }
    
        // override object.GetHashCode
        public override int GetHashCode()
        {
            // modify the code below to generate a unique hash code for your object.
            return base.GetHashCode();
        }
    }
