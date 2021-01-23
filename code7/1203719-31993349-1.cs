        [XmlText]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public XmlNode [] ValueString
        {
            get
            {
                if (Value == null)
                    return null;
                else if (Type == LogItemType.Xml)
                    // return CDATA
                    return new XmlNode[] { new XmlDocument().CreateCDataSection(Value) };
                else
                    // return string (not CDATA)
                    return new XmlNode[] { new XmlDocument().CreateTextNode(Value) };
            }
            set
            {
                Value = value == null ? null : string.Concat(value.Select(n => n.Value).ToArray());
            }
        }
