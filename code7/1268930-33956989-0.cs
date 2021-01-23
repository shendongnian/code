    try
    {
           const string uninstallName = "Uninstall";
           const string installName = "Install";
           const string discardName = "Discard";
           const string nameAttribute = "Name";
           const string mainElement = "Main";
           const string rootElement = "Root";
           XDocument xdoc = XDocument.Load("../../input.xml");
           XElement root = xdoc.Root;
           if (root == null)
               throw  new Exception("No root element found");
           var mains = root.Elements(mainElement);
           if (!mains.Any())
               throw new Exception(String.Format("No element named {0} was found", mainElement));
           var lastInstall = mains.LastOrDefault(m => m.Attribute(nameAttribute).Value == installName);
           var lastDiscard = mains.LastOrDefault(m => m.Attribute(nameAttribute).Value == discardName);
           var lastUninstall = mains.LastOrDefault(m => m.Attribute(nameAttribute).Value == uninstallName);
           XDocument output = new XDocument();
           output.Add(new XElement(rootElement));
           if (lastUninstall != null)
               output.Root.Add(lastUninstall);
           if (lastDiscard != null)
               output.Root.Add(lastDiscard);
           if (lastInstall != null)
               output.Root.Add(lastInstall);
           output.Save("output.xml");
                                
    }
    catch (Exception ex)
    {
         // log, write to output or anything
    }    
        
