    List<Attachment> AttachmentList = new List<Attachment>();
    JArray a = JArray.Parse(jsonString);
    foreach (JObject o in a.Children<JObject>())
    {
        Attachment newAttachment = new Attachment
        {
           WriteUpID = (int)o["WriteUpID"],
           InitialScanID = (int)o["InitialScanID"],
           //etc, do this for all Class items. 
        }
        AttachmentList.Add(newAttachment);
    }
    //Then change the AttachmentList to an array when you're done adding Attachments
    Attachment[] attachmentArray = AttachmentList.ToArray();  
