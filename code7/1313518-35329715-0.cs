    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class BODY
    {
        private BODYBAR bARField;
        /// <remarks/>
        public BODYBAR BAR
        {
            get
            {
                return this.bARField;
            }
            set
            {
                this.bARField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class BODYBAR
    {
        private string bRANField;
        private string sYSTField;
        private string cODEField;
        private string dESCField;
        private string dICLField;
        private string dOCLField;
        private ushort lENField;
        private byte sTSField;
        private byte pOSField;
        private byte sVLField;
        private byte iVLField;
        private byte vROTField;
        private byte vU1SField;
        private byte vU1DField;
        private byte vU2SField;
        private byte vU2DField;
        private decimal lENRField;
        private decimal hField;
        private byte mLTField;
        private byte sCPField;
        private byte bRSField;
        private byte iFSField;
        private byte bS1LField;
        private byte bS1RField;
        private byte bS2LField;
        private byte bS2RField;
        private byte eNTHField;
        private BODYBARCUT[] cUTField;
        /// <remarks/>
        public string BRAN
        {
            get
            {
                return this.bRANField;
            }
            set
            {
                this.bRANField = value;
            }
        }
        /// <remarks/>
        public string SYST
        {
            get
            {
                return this.sYSTField;
            }
            set
            {
                this.sYSTField = value;
            }
        }
        /// <remarks/>
        public string CODE
        {
            get
            {
                return this.cODEField;
            }
            set
            {
                this.cODEField = value;
            }
        }
        /// <remarks/>
        public string DESC
        {
            get
            {
                return this.dESCField;
            }
            set
            {
                this.dESCField = value;
            }
        }
        /// <remarks/>
        public string DICL
        {
            get
            {
                return this.dICLField;
            }
            set
            {
                this.dICLField = value;
            }
        }
        /// <remarks/>
        public string DOCL
        {
            get
            {
                return this.dOCLField;
            }
            set
            {
                this.dOCLField = value;
            }
        }
        /// <remarks/>
        public ushort LEN
        {
            get
            {
                return this.lENField;
            }
            set
            {
                this.lENField = value;
            }
        }
        /// <remarks/>
        public byte STS
        {
            get
            {
                return this.sTSField;
            }
            set
            {
                this.sTSField = value;
            }
        }
        /// <remarks/>
        public byte POS
        {
            get
            {
                return this.pOSField;
            }
            set
            {
                this.pOSField = value;
            }
        }
        /// <remarks/>
        public byte SVL
        {
            get
            {
                return this.sVLField;
            }
            set
            {
                this.sVLField = value;
            }
        }
        /// <remarks/>
        public byte IVL
        {
            get
            {
                return this.iVLField;
            }
            set
            {
                this.iVLField = value;
            }
        }
        /// <remarks/>
        public byte VROT
        {
            get
            {
                return this.vROTField;
            }
            set
            {
                this.vROTField = value;
            }
        }
        /// <remarks/>
        public byte VU1S
        {
            get
            {
                return this.vU1SField;
            }
            set
            {
                this.vU1SField = value;
            }
        }
        /// <remarks/>
        public byte VU1D
        {
            get
            {
                return this.vU1DField;
            }
            set
            {
                this.vU1DField = value;
            }
        }
        /// <remarks/>
        public byte VU2S
        {
            get
            {
                return this.vU2SField;
            }
            set
            {
                this.vU2SField = value;
            }
        }
        /// <remarks/>
        public byte VU2D
        {
            get
            {
                return this.vU2DField;
            }
            set
            {
                this.vU2DField = value;
            }
        }
        /// <remarks/>
        public decimal LENR
        {
            get
            {
                return this.lENRField;
            }
            set
            {
                this.lENRField = value;
            }
        }
        /// <remarks/>
        public decimal H
        {
            get
            {
                return this.hField;
            }
            set
            {
                this.hField = value;
            }
        }
        /// <remarks/>
        public byte MLT
        {
            get
            {
                return this.mLTField;
            }
            set
            {
                this.mLTField = value;
            }
        }
        /// <remarks/>
        public byte SCP
        {
            get
            {
                return this.sCPField;
            }
            set
            {
                this.sCPField = value;
            }
        }
        /// <remarks/>
        public byte BRS
        {
            get
            {
                return this.bRSField;
            }
            set
            {
                this.bRSField = value;
            }
        }
        /// <remarks/>
        public byte IFS
        {
            get
            {
                return this.iFSField;
            }
            set
            {
                this.iFSField = value;
            }
        }
        /// <remarks/>
        public byte BS1L
        {
            get
            {
                return this.bS1LField;
            }
            set
            {
                this.bS1LField = value;
            }
        }
        /// <remarks/>
        public byte BS1R
        {
            get
            {
                return this.bS1RField;
            }
            set
            {
                this.bS1RField = value;
            }
        }
        /// <remarks/>
        public byte BS2L
        {
            get
            {
                return this.bS2LField;
            }
            set
            {
                this.bS2LField = value;
            }
        }
        /// <remarks/>
        public byte BS2R
        {
            get
            {
                return this.bS2RField;
            }
            set
            {
                this.bS2RField = value;
            }
        }
        /// <remarks/>
        public byte ENTH
        {
            get
            {
                return this.eNTHField;
            }
            set
            {
                this.eNTHField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CUT")]
        public BODYBARCUT[] CUT
        {
            get
            {
                return this.cUTField;
            }
            set
            {
                this.cUTField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class BODYBARCUT
    {
        private byte nUMField;
        private object tYPEField;
        private byte aNGLField;
        private byte aNGRField;
        private byte aB1Field;
        private byte aB2Field;
        private ushort ilField;
        private decimal olField;
        private string bCODField;
        private object cSNAField;
        private object cSNUField;
        private object tINAField;
        private string dESCField;
        private byte sTATField;
        private string[] lBLField;
        /// <remarks/>
        public byte NUM
        {
            get
            {
                return this.nUMField;
            }
            set
            {
                this.nUMField = value;
            }
        }
        /// <remarks/>
        public object TYPE
        {
            get
            {
                return this.tYPEField;
            }
            set
            {
                this.tYPEField = value;
            }
        }
        /// <remarks/>
        public byte ANGL
        {
            get
            {
                return this.aNGLField;
            }
            set
            {
                this.aNGLField = value;
            }
        }
        /// <remarks/>
        public byte ANGR
        {
            get
            {
                return this.aNGRField;
            }
            set
            {
                this.aNGRField = value;
            }
        }
        /// <remarks/>
        public byte AB1
        {
            get
            {
                return this.aB1Field;
            }
            set
            {
                this.aB1Field = value;
            }
        }
        /// <remarks/>
        public byte AB2
        {
            get
            {
                return this.aB2Field;
            }
            set
            {
                this.aB2Field = value;
            }
        }
        /// <remarks/>
        public ushort IL
        {
            get
            {
                return this.ilField;
            }
            set
            {
                this.ilField = value;
            }
        }
        /// <remarks/>
        public decimal OL
        {
            get
            {
                return this.olField;
            }
            set
            {
                this.olField = value;
            }
        }
        /// <remarks/>
        public string BCOD
        {
            get
            {
                return this.bCODField;
            }
            set
            {
                this.bCODField = value;
            }
        }
        /// <remarks/>
        public object CSNA
        {
            get
            {
                return this.cSNAField;
            }
            set
            {
                this.cSNAField = value;
            }
        }
        /// <remarks/>
        public object CSNU
        {
            get
            {
                return this.cSNUField;
            }
            set
            {
                this.cSNUField = value;
            }
        }
        /// <remarks/>
        public object TINA
        {
            get
            {
                return this.tINAField;
            }
            set
            {
                this.tINAField = value;
            }
        }
        /// <remarks/>
        public string DESC
        {
            get
            {
                return this.dESCField;
            }
            set
            {
                this.dESCField = value;
            }
        }
        /// <remarks/>
        public byte STAT
        {
            get
            {
                return this.sTATField;
            }
            set
            {
                this.sTATField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LBL")]
        public string[] LBL
        {
            get
            {
                return this.lBLField;
            }
            set
            {
                this.lBLField = value;
            }
        }
    }
