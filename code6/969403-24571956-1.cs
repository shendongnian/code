    public class Company
    {
        public string Task { get; set; }
        public string durationTotal { get; set; }
        public string HeadNote { get; set; }
        public List<Model> Models { get; set; }
    }
    public class Model
    {
        public string SubTask { get; set; }
        public string Duration { get; set; }
        public string Notes { get; set; }      
    }
___
       List<Company> ManufacturerList = new List<Company>();
            ManufacturerList.Add(new Company()
            {
                Task = "Coding",
                durationTotal = "4",
                HeadNote = "Coding Task",
                Models = new List<Model>()
                {new Model(){SubTask = "Write", Duration = "2", Notes ="It pays the bills" },
                new Model(){SubTask = "Compile", Duration = "1", Notes ="c# or go home" },
                new Model(){SubTask = "Test", Duration = "1", Notes ="works on my m/c" },}
            });
            ManufacturerList.Add(new Company()
            {
                Task = "Communicate",
                durationTotal = "2",
                HeadNote = "Communicate Task",
                Models = new List<Model>()
                {new Model(){SubTask = "Email", Duration = "0.5", Notes ="so much junk mail"  },
                new Model(){SubTask = "Blogs", Duration = "0.25", Notes ="blogs.msdn.com/delay" },
                new Model(){SubTask = "Twitter", Duration = "0.25", Notes ="RT:nothing to report" },}
            });
            treeviewList.ItemsSource = ManufacturerList;
