                string strElem = "<adress name=\"company1\" street=\"street1\" City=\"city1\"><branch key=\"1\" value=\"branch1\" /><language key=\"1\" value=\"langauge1\" /> </adress>";
                XElement xel = XElement.Parse(strElem);
    
                var theTable = new ExpandoObject() as IDictionary<string, Object>;
                foreach (XAttribute attr in xel.Attributes())
                {
                    theTable.Add(attr.Name.LocalName, attr.Value);
                }
    
                foreach (XElement el in xel.Elements())
                {
                    foreach (XAttribute attr in el.Attributes())
                    {
                        theTable.Add(el.Name + attr.Name.LocalName, attr.Value);
                    }
                }
