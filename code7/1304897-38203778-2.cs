    List<XElement> elements = new List<XElement>();
     while (XMLDoc.ReadToFollowing("ElementName"))
         {
       using (XmlReader r = XMLDoc.ReadSubtree())
          {
       r.Read();
       XElement node = XElement.Load(r);
    //do some processing of the node here...
    elements.Add(node);
    }
    }
    //And now pass the list of elements through PLinQ to the actual web service call, allowing the OS/framework to handle the parallelism
    
    int failCount=0; //the method call below sets this per request; we log and continue
    
    failCount = elements.AsParallel()
                                .Sum(element => IntegrationClass.DoRequest(element.ToString()));
