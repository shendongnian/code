    using System.Resources;
    using (ResXResourceReader oReader = new ResXResourceReader(ResourceFilePath))
    {
          IDictionaryEnumerator oResource = oReader.GetEnumerator();
          while (oResource.MoveNext())
          {
               if (oResource.Value.ToString() == "VALUE")
                   return oResource.Key.ToString();
          }
     }
