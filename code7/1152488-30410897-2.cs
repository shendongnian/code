    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    using System.Data;
    namespace Shape
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xmlSample = "<?xml version=\"1.0\"?><NewDataSet xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Shape xsi:type=\"Rectangle\"><Width>2</Width><Height>5</Height><Color>Red</Color></Shape></NewDataSet>";
                StringReader reader = new StringReader(xmlSample);
                XmlSerializer xs = new XmlSerializer(typeof(NewDataSet));
                NewDataSet ds = (NewDataSet)xs.Deserialize(reader);
               
            }
        }
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [XmlInclude(typeof(Rectangle))]
        [XmlInclude(typeof(Square))]
        [XmlRoot("Shape")]
        public partial class Shape
        {
            private string widthField;
            private string heightField;
            private string colorField;
            /// <remarks/>
            [XmlElement("Width")]
            public string Width
            {
                get
                {
                    return this.widthField;
                }
                set
                {
                    this.widthField = value;
                }
            }
            /// <remarks/>
            [XmlElement("Height")]
            public string Height
            {
                get
                {
                    return this.heightField;
                }
                set
                {
                    this.heightField = value;
                }
            }
            /// <remarks/>
            [XmlElement("Color")]
            public string Color
            {
                get
                {
                    return this.colorField;
                }
                set
                {
                    this.colorField = value;
                }
            }
        }
        [XmlRoot("Rectangle")]
        public class Rectangle : Shape
        {
        }
        [XmlRoot("Square")]
        public class Square : Shape
        {
        }
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        //[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        [XmlRoot("NewDataSet")]
        public partial class NewDataSet
        {
            private Shape[] itemsField;
            /// <remarks/>
            [XmlElement("Shape")]
            public Shape[] Items
            {
                get
                {
                    return this.itemsField;
                }
                set
                {
                    this.itemsField = value;
                }
            }
        }
    }
    ​
