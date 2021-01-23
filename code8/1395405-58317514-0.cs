var message = new MimeMessage();
// add from, to, subject and other needed properties to your message
var builder = new BodyBuilder();
builder.HtmlBody = htmlContent;
builder.TextBody = textContent;
// you can either create MimeEntity object(s)
// this might get handy in case you want to pass multiple attachments from somewhere else
byte[] myFileAsByteArray = LoadMyFileAsByteArray();
var attachments = new List<MimeEntity>
{
    // from file
    MimeEntity.Load("myFile.pdf"),
    // file from stream
    MimeEntity.Load(new MemoryStream(myFileAsByteArray)),
    // from stream with a content type defined
    MimeEntity.Load(new ContentType("application", "pdf"), new MemoryStream(myFileAsByteArray))
}
// or add file directly - there are a few more overloads to this
builder.Attachments.Add("myFile.pdf");
builder.Attachments.Add("myFile.pdf", myFileAsByteArray);
builder.Attachments.Add("myFile.pdf", myFileAsByteArray , new ContentType("application", "pdf"));
// append previously created attachments
foreach (var attachment in attachments)
{
    builder.Attachments.Add(attachment);
}
message.Body = builder.ToMessageBody();
Hope it helps.
