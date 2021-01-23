    [DebuggerDisplay("MyNotUsedStringKey = {MyNotUsedStringKey}")]
    public class ImportParent
    {
        public ImportParent()
        {
            this.MyNotUsedStringKey = Guid.NewGuid().ToString("N");
            this.ImportChildren = new ImportChildCollection();
        }
    
        public ImportChildCollection ImportChildren { get; set; }
        public string MyNotUsedStringKey { get; set; }
    
    }
    
    public class ImportChildCollection : List<ImportChild>
    {
        public ImportChildCollection() { }
        public ImportChildCollection(IEnumerable<ImportChild> src)
        {
            if (null != src)
            {
                foreach (ImportChild item in src)
                {
                    item.Ordinal = this.Count + 1;
                    base.Add(item);
                }
            }
    
            //AddRange(src);
        }
    }
    
    [DebuggerDisplay("MyStringKey = {MyStringKey}, MyStringValue='{MyStringValue}', Ordinal='{Ordinal}'")]
    public class ImportChild
    {
        public ImportChild()
        {
        }
    
        public int Ordinal { get; set; }
        public string MyStringKey { get; set; }
        public string MyStringValue { get; set; }
    }
    
    
    
    
                string xmlString = @"<?xml version=""1.0"" encoding=""utf-8"" ?> 
                <xml>
    	            <result>OK</result> 
    	            <headers>
    		            <header>lastname</header>
    		            <header>firstname</header>
    		            <header>Age</header>
    	            </headers>
    	            <data>
    		            <datum>
    			            <item>Kelly</item>
    			            <item>Grace</item>
    			            <item>33</item>
    		            </datum>
    	            </data>
                </xml>       	 ";
    
                XDocument xDoc = XDocument.Parse(xmlString);
    
                //XNamespace ns = XNamespace.Get("http://schemas.microsoft.com/developer/msbuild/2003");
                string ns = string.Empty;
    
    
    
    
                List<ImportParent> parentKeys = new List<ImportParent>
                (
                    from list in xDoc.Descendants(ns + "xml")
                    from item1 in list.Elements(ns + "headers")
                    where item1 != null
                    select new ImportParent
                    {
                        //note that the cast is simpler to write than the null check in your code
                        //http://msdn.microsoft.com/en-us/library/bb387049.aspx
                        ImportChildren = new ImportChildCollection
                        (
                            from detail in item1.Descendants("header")
                            select new ImportChild
                            {
                                MyStringKey = detail == null ? string.Empty : detail.Value
                            }
                        )
                    }
                );
    
    
                List<ImportParent> parentValues = new List<ImportParent>
                (
                    from list in xDoc.Descendants(ns + "xml")
                    from item1 in list.Elements(ns + "data")
                    from item2 in item1.Elements(ns + "datum")
                    where item1 != null && item2 != null
                    select new ImportParent
                    {
                        //note that the cast is simpler to write than the null check in your code
                        //http://msdn.microsoft.com/en-us/library/bb387049.aspx
                        ImportChildren = new ImportChildCollection
                            (
                                from detail in item1.Descendants("item")
                                select new ImportChild
                                {
                                    MyStringValue = detail == null ? string.Empty : detail.Value
                                }
                            )
                    }
                );
    
                /*Match up the Keys to the Values using "Ordinal" matches*/
                foreach (ImportParent parent in parentKeys)
                {
                    foreach (ImportChild child in parent.ImportChildren)
                    {
                        ImportChild foundMatch = parentValues.SelectMany(x => x.ImportChildren).Where(c => c.Ordinal == child.Ordinal).FirstOrDefault();
                        if (null != foundMatch)
                        {
                            child.MyStringValue = foundMatch.MyStringValue;
                        }
                    }
                }
    
                foreach (ImportParent parent in parentKeys)
                {
                    foreach (ImportChild child in parent.ImportChildren)
                    {
                        Console.WriteLine("Key={0}, Value={1}", child.MyStringKey, child.MyStringValue);
                    }
                }
    
    
                
