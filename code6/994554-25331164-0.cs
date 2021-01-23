     /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://model.ws.solution.client.com")]
        public partial class ComprobanteConstatarResponse {
            
            private string codeField;
            
            private string fch_procesoField;
            
            private string msgField;
            
            private string resultadoField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
            public string code {
                get {
                    return this.codeField;
                }
                set {
                    this.codeField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
            public string fch_proceso {
                get {
                    return this.fch_procesoField;
                }
                set {
                    this.fch_procesoField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
            public string msg {
                get {
                    return this.msgField;
                }
                set {
                    this.msgField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
            public string resultado {
                get {
                    return this.resultadoField;
                }
                set {
                    this.resultadoField = value;
                }
            }
        }
