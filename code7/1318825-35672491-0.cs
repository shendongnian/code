    public class ResponseBaseVM
        {
            public string ErrorReason { get; set; }
            /*public bool IsRejected { get; set; }*/ 
        }
    public class ReadingVM : ResponseBaseVM
        {
            //Other properties that you only want available to user
        }
