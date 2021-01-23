    // An example document with spatial data
    public class MyDocument 
    {
        public string Id { get; set; }
        public Microsoft.Azure.Documents.Spatial.Point Location { get; set; }
    }
    // An example distance query - get all documents within 30 km of a given point
    client.CreateDocumentQuery<MyDocument>(collection.SelfLink)
        .Where(x => x.Location.Distance(new Point(32.33, -4.66)) < 30000))
   
