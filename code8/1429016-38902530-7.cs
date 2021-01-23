    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
       [SerializableAttribute()]
       [DesignerCategoryAttribute("code")]
       [XmlTypeAttribute(AnonymousType = true)]
       [XmlRootAttribute(Namespace = "", IsNullable = false)]
       public class ConstituencyResults
       {
          private ConstituencyResult _constituencyResultField;
          public ConstituencyResult ConstituencyResult
          {
             get { return _constituencyResultField; }
             set { _constituencyResultField = value; }
          }
       }
       [SerializableAttribute()]
       [DesignerCategoryAttribute("code")]
       [XmlTypeAttribute(AnonymousType = true)]
       public class ConstituencyResult
       {
          private byte _consituencyIdField;
          private string _constituencyNameField;
          private ConstituencyData[] Data;
          private byte _seqNoField;
          public byte ConsituencyId
          {
             get { return _consituencyIdField; }
             set { _consituencyIdField = value; }
          }
          public string ConstituencyName
          {
             get { return _constituencyNameField; }
             set { _constituencyNameField = value; }
          }
          [XmlArrayItemAttribute("Result", IsNullable = false)]
          public ConstituencyData[] Results
          {
            get { return Data; }
            set { Data = value; }
          }
          [XmlAttributeAttribute()]
          public byte SeqNo
          {
            get { return _seqNoField; }
            set { _seqNoField = value; }
          }
       }
       [SerializableAttribute()]
       [DesignerCategoryAttribute("code")]
       [XmlTypeAttribute(AnonymousType = true)]
       public class ConstituencyData
       {
          private string _partyCodeField;
          private ushort _votesField;
          private decimal _shareField;
          public string PartyCode
          {
             get { return _partyCodeField; }
             set { _partyCodeField = value; }
          }
          public ushort Votes
          {
             get { return _votesField; }
             set { _votesField = value; }
          }
          public decimal Share
          {
             get { return _shareField; }
             set { _shareField = value; }
          }
       }
    }
