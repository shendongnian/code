    [Serializable]
    public class DapperResultSet : IEnumerable<object>
{
    public List<object> Rows { get; set; }
    public void Add(dynamic o)
    {
        Rows.Add(o);
    }
    
    public DapperResultSet()
    {
        Rows = new List<object>();
    }
    public IEnumerator<object> GetEnumerator()
    {
        return Rows.GetEnumerator();
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
