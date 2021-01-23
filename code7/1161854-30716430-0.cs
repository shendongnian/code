        //Test suites
        [System.Xml.Serialization.XmlArray("TestSuites")]
        [System.Xml.Serialization.XmlArrayItem("Test", IsNullable = false)]
        public string[] Testsuites
        {
            get { return this._testSuites; }
            set { this._testSuites = value; }
        }
