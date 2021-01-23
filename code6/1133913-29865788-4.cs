    public class Message
    {
     public string area {get;set;}
     public string desc {get;set;}
     public string image {get;set;}
    }
    Message message = new JavaScriptSerializer().Deserialize<Message>(result);
    
    byte[] imageData = Convert.FromBase64String(message.image);
    MemoryStream ms = new MemoryStream(imageData);
    Image returnImage = Image.FromStream(ms);
