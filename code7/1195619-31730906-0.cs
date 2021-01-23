    public class Foo
    {
        string CardNumber { get; set;}
        string ExpMo { get; set; }
        string ExpYr { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        public String WriteXml()
        {
            string xmlContent =
            string.Format("<CardNumber>{0}</CardNumber>" +
            "<ExpMo>{1}</ExpMo>" +
            "<ExpYr>{2}</ExpYr>" +
            "<FirstName>{3}</FirstName>" +
            "<LastName>{4}</LastName>",
            CardNumber, ExpMo, ExpYr, FirstName, LastName);
            return xmlContent;
        }
    }
