private string Create(Task<Document> task)
{
    var doc = Task.Run(() => task).Result;
    return doc.Id;
}
[HttpPost]
public ActionResult CreateConfig(MyConfig config)
{
     var task = Client.CreateDocumentAsync(CollectionUri, config);
     var id = Create(task).Result;
     return Json(id);
}
So even running things on the thread pool may not be the ultimate solution. It seems an equally import factor to consider is what `SynchonizationContext` was in effect when the **async method's task** was created.
