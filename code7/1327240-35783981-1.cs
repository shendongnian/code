     public class StatusUpdate
        {
           public StatusUpdate()
           {
               Status = "";
               ErrorMessage = "";
               IsIndeterminate = true;
           }
            public string Status { get; set; }
            public string ErrorMessage { get; set; }
            public bool IsIndeterminate { get; set; }
        }
    }
