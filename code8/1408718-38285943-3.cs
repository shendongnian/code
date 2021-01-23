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
            Group = ProcessNames::GetGroupFromProcessName(Name);
        }
    
        public ProcessInfo(string name, int id, TimeSpan time)
        {
            Name = name;
            Id = id;
            Time = time;
        }
    }
    internal static class ProcessNames
    {
        private static Dictionary<string, string> _names;
        public static string GetGroupNameFromProcessName(string name)
        {
            // Make sure to add locking if there is a possibility of using
            // this from multiple threads.
            if(_names == null)
            {
                // Load dictionary from JSON file
            }
            // Return the value from the Dictionary here, if it exists.
        }
    }
