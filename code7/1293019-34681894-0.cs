    public class ViewModel
    {
        public Smart_WEB.Models.Room Room { get; set; }
        public List<IGrouping<string, Smart_WEB.Models.Song>> Songs { get; set; }
        List<IGrouping<string, Smart_WEB.Models.Video>> Videos { get; set; }
    }
