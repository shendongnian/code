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
        [XmlElement(ElementName = "Tags")]
        public Tags Tags { get; set; }
        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            // modify the code below to suit your needs...
            test objA = (test)obj;
            if (
                    this.ID != objA.ID || this.Name != objA.Name
                    || this.Details.duration != objA.Details.duration || this.Details.starttime != objA.Details.starttime || this.Details.endtime != objA.Details.endtime
                    || this.Remark.IsRemarkVisible != objA.Remark.IsRemarkVisible || this.Remark.RemarkText != objA.Remark.RemarkText
                ) return false;
            if (this.Tags.TagLocation.Length != objA.Tags.TagLocation.Length) return false;
            for (int i = 0; i < this.Tags.TagLocation.Length; i++)
            {
                if (this.Tags.TagLocation[i].Id != objA.Tags.TagLocation[i].Id || this.Tags.TagLocation[i].TagText != objA.Tags.TagLocation[i].TagText) return false;
            }
            return true;    // if everything matched we infer that the objects are equal.
        }
        // override object.GetHashCode
        public override int GetHashCode()
        {
            // modify the code below to generate a unique hash code for your object.
            return base.GetHashCode();
        }
    }
