            string filepath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\OBJECTS.xml"; 
           //Path to XML file
 
            List<yourObject> list = new List<yourObject>();
            var maps = from c in XElement.Load(filepath).Elements("Object")
                       select c;
            foreach (var item in maps)
            {
                var newObject= new yourObject();
                //Names of your nodes
                newObject.Server= item.Element("Server").Value;
                newObject.Issue= item.Element("Issue").Value;
                
                list.Add(newObject);
            }
            //Probably a good idea to make it an observable collection.
            objectList= new ObservableCollection<youtObject>();
            foreach (var item in list)
            {
                objectList.Add(item);
            }
