                using (XmlReader xr = XmlReader.Create(path))
                {
                     xr.MoveToContent();
                     XNamespace un = xr.LookupNamespace("un");
                     XNamespace xn = xr.LookupNamespace("xn");
                     XNamespace es = xr.LookupNamespace("es");
                     while (!xr.EOF)
                     {
                         if(xr.LocalName != "UtranCell")
                         {
                             xr.ReadToFollowing("UtranCell", un.NamespaceName);
                         }
                         if(!xr.EOF)
                         {
                             XElement utranCell = (XElement)XElement.ReadFrom(xr);
                         }
                    }
                }
