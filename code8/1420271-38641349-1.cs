    [XmlType(AnonymousType = true, IncludeInSchema = false)]
    public class XmlGuid
    {
        [XmlIgnore]
        public Guid Guid { get; set; }
        [XmlText]
        public string XmlCardNumber
        {
            get
            {
                if (Guid == Guid.Empty)
                    return null;
                return XmlConvert.ToString(Guid);
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    Guid = Guid.Empty;
                else
                    Guid = XmlConvert.ToGuid(value);
            }
        }
        public static implicit operator Guid?(XmlGuid x)
        {
            if (x == null)
                return null;
            return x.Guid;
        }
        public static implicit operator XmlGuid(Guid? g)
        {
            if (g == null)
                return null;
            return new XmlGuid { Guid = g.Value };
        }
        public static implicit operator Guid(XmlGuid x)
        {
            if (x == null)
                return Guid.Empty;
            return x.Guid;
        }
        public static implicit operator XmlGuid(Guid g)
        {
            return new XmlGuid { Guid = g };
        }
    }
