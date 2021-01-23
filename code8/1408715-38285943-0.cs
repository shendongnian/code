    public class ProcessInfo
    {
        private string _name;
        private string Name
        { 
          get { return _name; }
          set
          {
              _name = value;
              UpdateGroupName();
          }
        }
        private int Id { get; set; }
        private TimeSpan Time { get; set; }
        private string Group { get; set; }
        private void UpdateGroupName()
        {
            switch(Name)
            {
               case "devenv.exe":
                   Group = "Software Development;
                   break;
               default:
                   Group = "Default";
                   break;
             }
         }
    
        public ProcessInfo(string name, int id, TimeSpan time)
        {
            Name = name;
            Id = id;
            Time = time;
        }
    }
