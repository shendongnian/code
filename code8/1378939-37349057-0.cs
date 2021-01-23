        public void Main()
        		{
        
                    string filename = Convert.ToString(Dts.Variables["User::File_Name"].Value);
        
                    XDocument xml = new XDocument();
        
                    var doc = XDocument.Load(filename);
                    
                    var element1 = doc.Root.Elements().Where(o => o.Name.LocalName.Equals("bob"));
                    var element2 = doc.Root.Elements().Where(o => o.Name.LocalName.Equals("mice"));
                    var element3 = doc.Root.Elements().Where(o => o.Name.LocalName.Equals("car"));
                    var element4 = doc.Root.Elements().Where(o => o.Name.LocalName.Equals("dog"));
                    var element5 = doc.Root.Elements().Where(o => o.Name.LocalName.Equals("cat"));
                    var element6 = doc.Root.Elements().Where(o => o.Name.LocalName.Equals("number"));
                    var element7 = doc.Root.Elements().Where(o => o.Name.LocalName.Equals("thing"));
        
                    var newElement = new XElement("New_Tag", element1, element2, element3, element4, element5, element6, element7);
                    doc.Root.Element("Some_Tag").AddBeforeSelf(newElement);
        
                    element1.Remove();
                    element2.Remove();
                    element3.Remove();
                    element4.Remove();
                    element5.Remove();
                    element6.Remove();
                    element7.Remove();
        
                    doc.Save(filename);
        
        			Dts.TaskResult = (int)ScriptResults.Success;
        		}
