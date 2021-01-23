    public class Message
    {
     public string Area {get;set;}
     public string Description {get;set;}
     public string Image {get;set;}
    }
    Message message = new JavaScriptSerializer().Deserialize<Message>(result);
    
    byte[] imageData = Convert.FromBase64String(message.image);
    MemoryStream ms = new MemoryStream(imageData);
    Image returnImage = Image.FromStream(ms);
