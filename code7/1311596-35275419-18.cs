    namespace  XmlStuff {
      [DataContract(Namespace = "")]
      public class myLongChild
      {
        [DataMember]
        public double myLongText { get; set; }
      }
      [DataContract(Namespace = "")]
      public class myLongRoot
      {
        [DataMember]
        public IList<myLongChild> Items { get; set; }
      }
    }
    
