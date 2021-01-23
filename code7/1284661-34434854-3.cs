    void Main()
    {
     	var path = @"... path to your sample xml";
        // you could skip this step, and deserialize directly from a file stream.
      	var xml = XElement.Load(path);
       	var nds = new XmlSerializer(typeof(NewDataSet)).Deserialize(xml.CreateReader());
       	nds.Dump();
    }
        
    public class NewDataSet
    {
    	public Patient Patient { get; set; }
    	[XmlElement("MeasureRec")]
    	public MeasureRec[] Recs { get; set; }
    	[XmlElement("Comment")]
    	public Comment[] Comment { get; set; }
    }
    
    public class MeasureRec
    {
    	public int Pulse { get; set; }
    }
    
    public class Comment
    {
    	[XmlElement("Comment")]
    	public string Text { get; set; }
    }
    
    public class Patient
    {
    	public string FamilyName { get; set; }
    	public string GivenNames { get; set; }
    }
