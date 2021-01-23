     [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class Polygons
        {
            private Polygon[] _field;
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Polygon")]
            public Polygon[] Polygon
            {
                get
                {
                    return this._field;
                }
                set
                {
                    this._field = value;
                }
            }
        }
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class Polygon
        {
            private Point2D[] pointsField;
            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("Point2D", IsNullable = false)]
            public Point2D[] Points
            {
                get
                {
                    return this.pointsField;
                }
                set
                {
                    this.pointsField = value;
                }
            }
        }
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class Point2D
        {
            private byte xField;
            private byte yField;
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte X
            {
                get
                {
                    return this.xField;
                }
                set
                {
                    this.xField = value;
                }
            }
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Y
            {
                get
                {
                    return this.yField;
                }
                set
                {
                    this.yField = value;
                }
            }
        }
