        public void ReadData(Container kon)
        {
          using (StreamReader reader = new StreamReader("C:\\Users\\Sparta\\Documents\\Visual Studio 2015\\WebSites\\WebSite4\\u22b.txt"))
          {
         LinkedList list = new LinkedList();
                        string line = null;
                        while ((line = reader.ReadLine()) != null)
                        {
                            
                            string[] values = line.Split(';');
                            
                            ProjectWork temp = new ProjectWork(values[0], values[1], int.Parse(values[2]));
                            list.AddToEnd(temp);
                         }
           }
        }
    
    class ProjectWork
        {
            public string Lesson { get; set; }
            public string FullName { get; set; }
            public int Credits { get; set; }
            public ProjectWork(string _lesson, string _fullname, int _credits)
            {
                Lesson = _lesson;
                FullName = _fullname;
                Credits = _credits;
            }
        }
      class LinkedList
        {
            public void AddToEnd(ProjectWork data)
            {
               var myFullName =  data.FullName;
               var Lesson = data.Lesson;
               var Credits = data.Credits;
    
                //
            }
        }
