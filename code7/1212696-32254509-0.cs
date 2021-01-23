    public class MessageSystem
    {
         //This is for bootstrap. This will reference what type of alert we will throw.
        public MessageType Type { get; set; }
        //Where the message you want to say will be held
        public string Message { get; set; }
        //Creates the HTML string.
        //This outputs the div in HTML with the current message formatted. 
        public string Generate()
        {
            //Div Tag
            var divTag = new TagBuilder("div");
                divTag.AddCssClass("alert alert-" + Type.ToString());
                divTag.InnerHtml = Message + "<span class=\"glyphicon glyphicon-remove js-close\"></span>";
                return divTag.ToString();
        }
    }
     //The bootstrap alert types.
    public enum MessageType
    {
        success,
        info,
        warning,
        danger
    }
