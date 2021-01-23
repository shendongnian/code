    public class Favorite
    {
        public string Name { get; private set; }
        public string Notes { get; set; }
        public bool NotesFromPlanner { get; set; }
        public string Project { get; set; }
        public string DbLocation { get; set; }
        public string AssesmentToolVersion { get; set; }
        public string ProjectCodes { get; set; }
        public bool StraightToNew { get; set; }
        public Favorite(string name)
        {
            this.Name = name;
        }
        public void Save()
        {
            var reg = new RegHelper(this.Name);
            reg.SetProperty("Name", Name);
            reg.SetProperty("Notes", Notes);
            reg.SetProperty("NotesFromPlanner", NotesFromPlanner);
            reg.SetProperty("Project", Project);
            reg.SetProperty("DbLocation", DbLocation);
            reg.SetProperty("AssesmentToolVersion", AssesmentToolVersion);
            reg.SetProperty("ProjectCodes", ProjectCodes);
            reg.SetProperty("StraightToNew", StraightToNew);
        }
        public static Favorite GetFavorite(string favoriteName)
        {
            var reg = new RegHelper(favoriteName);
            return new Favorite(favoriteName)
            {
                Notes = reg.GetProperty("Notes"),
                NotesFromPlanner = reg.GetPropertyAsBool("NotesFromPlanner"),
                Project = reg.GetProperty("Project"),
                DbLocation = reg.GetProperty("DbLocation"),
                AssesmentToolVersion = reg.GetProperty("AssesmentToolVersion"),
                ProjectCodes = reg.GetProperty("ProjectCodes"),
                StraightToNew = reg.GetPropertyAsBool("StraightToNew"),
            };
        }
        public static List<Favorite> GetFavorites()
        {
            return new RegHelper().GetSubKeys().Select(GetFavorite).ToList();
        }
    }
