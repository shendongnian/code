    public class MyModel
    {
        public string CssClass
        {
            get
            {
                return Deadline.Date < DateTime.Today && !Completed ? "overdue" : "notoverdue";
            }
        }
    }
