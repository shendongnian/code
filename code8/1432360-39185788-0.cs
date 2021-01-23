    [System.Xml.Serialization.XmlElementAttribute("Row", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RTACModuleDeviceConnectionSettingPagesSettingPage[] Row
        {
            get
            {
                return this.rowField;
            }
            set
            {
                this.rowField = value;
            }
        }
        [System.Xml.Serialization.XmlElementAttribute("Setting", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<RTACModuleDeviceConnectionSettingPagesSettingPageRowSetting> Setting
        {
            get
            {
                return this.settingField;
            }
            set
            {
                this.settingField = value;
            }
        }
