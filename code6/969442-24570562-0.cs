    [Serializable]
    public struct sMatrixRow
    {
        public sMatrixRow(float col1, float col2, float col3, float col4)
        {
            this.col1 = col1;
            this.col2 = col2;
            this.col3 = col3;
            this.col4 = col4;
        }
        public float col1;
        public float col2;
        public float col3;
        public float col4;
    }
    [Serializable]
    public struct sMatrix
    {
        public sMatrixRow Row1
        {
            get
            {
                return new sMatrixRow(m00, m01, m02, m03);
            }
            set
            {
                this.m00 = value.col1;
                this.m01 = value.col2;
                this.m02 = value.col3;
                this.m03 = value.col4;
            }
        }
        // And so on, for Rows 2 through 4
        [System.NonSerialized, System.Xml.Serialization.XmlIgnore]
        public float m00;
        [System.NonSerialized, System.Xml.Serialization.XmlIgnore]
        public float m01;
        [System.NonSerialized, System.Xml.Serialization.XmlIgnore]
        public float m02;
        [System.NonSerialized, System.Xml.Serialization.XmlIgnore]
        public float m03;
        [System.NonSerialized, System.Xml.Serialization.XmlIgnore]
        public float m10;
        [System.NonSerialized, System.Xml.Serialization.XmlIgnore]
        public float m11;
        [System.NonSerialized, System.Xml.Serialization.XmlIgnore]
        public float m12;
        [System.NonSerialized, System.Xml.Serialization.XmlIgnore]
        public float m13;
        [System.NonSerialized, System.Xml.Serialization.XmlIgnore]
        public float m20;
        [System.NonSerialized, System.Xml.Serialization.XmlIgnore]
        public float m21;
        [System.NonSerialized, System.Xml.Serialization.XmlIgnore]
        public float m22;
        [System.NonSerialized, System.Xml.Serialization.XmlIgnore]
        public float m23;
        [System.NonSerialized, System.Xml.Serialization.XmlIgnore]
        public float m30;
        [System.NonSerialized, System.Xml.Serialization.XmlIgnore]
        public float m31;
        [System.NonSerialized, System.Xml.Serialization.XmlIgnore]
        public float m32;
        [System.NonSerialized, System.Xml.Serialization.XmlIgnore]
        public float m33;
    }
