    //I would create a class to use if you haven't
    //Just cleaner and easier to read
    public class Entry
    {
        public string MyMail { get; set; }
        public string ManagerMail { get; set; }
        public string Entity { get; set; }
        public string ProjectTitle { get; set; }
        // ......etc
    }
    //in case your format location ever changes only change the index value here
    public enum EntryLocation
    {
        MyMail = 0,
        ManagerMail = 1,
        Entity = 2,
        ProjectTitle = 3
    }
    //return the entry
    private Entry ReadEntry()
    {
        string s =
            string.Format("My mail: test@test.com{0}Manager mail: test2@test2.com{0}Entity: test entity{0}Project Title: test project title", Environment.NewLine);
         
        //in case you change your delimiter  only need to change it once here
        char delimiter = ':';
        //your entry contains newline so lets split on that first
        string[] split = s.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        //populate the entry
        Entry entry = new Entry()
        {
            //use the enum makes it cleaner to read what value you are pulling
            MyMail = split[(int)EntryLocation.MyMail].Split(delimiter)[1].Trim(),
            ManagerMail = split[(int)EntryLocation.ManagerMail].Split(delimiter)[1].Trim(),
            Entity = split[(int)EntryLocation.Entity].Split(delimiter)[1].Trim(),
            ProjectTitle = split[(int)EntryLocation.ProjectTitle].Split(delimiter)[1].Trim()
        };
        return entry;
    }
