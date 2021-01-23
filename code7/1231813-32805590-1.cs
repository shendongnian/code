    public class Root : SortedDictionary<string, Sheet>
    {
    }
    public class Sheet : SortedDictionary<string, Row>
    {
    }
    public class Row : SortedDictionary<string, string>
    {
    }
