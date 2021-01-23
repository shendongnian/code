    using (ResXResourceWriter resx = new ResXResourceWriter(@".\CarResources.resx"))
      {
         resx.AddResource("Title", "Classic American Cars");
         resx.AddResource("HeaderString1", "Make");
         resx.AddResource("HeaderString2", "Model");
         resx.AddResource("HeaderString3", "Year");
         resx.AddResource("HeaderString4", "Doors");
         resx.AddResource("HeaderString5", "Cylinders");
         resx.AddResource("Information", SystemIcons.Information);   
      }
