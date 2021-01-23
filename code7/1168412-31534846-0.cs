    public class  MyXmlDsigExcC14NTransform : XmlDsigExcC14NTransform 
    { 
       public MyXmlDsigExcC14NTransform() {} 
    
       public override  void LoadInput(Object obj) 
       {            
          XmlElement root = ((XmlDocument)obj).DocumentElement; 
          if (root.Name == "SignedInfo") root.RemoveAttribute("xml:id");            
          base.LoadInput(obj);                      
       } 
    }
