    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml;
    
    namespace SO_AddOrder
    {
    	class Program
    	{
    		const string Xml = @"<AddOrderResult xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
      <ErrorMessage i:nil=""true"" xmlns=""http://schemas.datacontract.org/2004/07/appulsive.Intertek.LIMSService"" />
      <Result i:nil=""true"" xmlns=""http://schemas.datacontract.org/2004/07/appulsive.Intertek.LIMSService"" />
      <ResultStatus xmlns=""http://schemas.datacontract.org/2004/07/appulsive.Intertek.LIMSService"">true</ResultStatus>
      <Order>
        <Kto>10025</Kto>
        <LIMSIdentifier>12345</LIMSIdentifier>
        <Matchcode>test order 1</Matchcode>
        <OfficeLineHandle>547864</OfficeLineHandle>
        <OverruleCreditCheck>true</OverruleCreditCheck>
      </Order>
    </AddOrderResult>";
    
    		static void Main(string[] args)
    		{
    			AddOrderResult res;
    			using (MemoryStream stream = new MemoryStream(Encoding.Default.GetBytes(Xml)))
    			{
    				stream.Position = 0;
    				XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());
    				DataContractSerializer ser = new DataContractSerializer(typeof(AddOrderResult), new Type[] { typeof(AddResult) });
    				res = (AddOrderResult)ser.ReadObject(reader, true);
    			}
    			Console.WriteLine(res.ResultStatus);
    		}
    	}
    
    	
    
    	// Define other methods and classes here
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/appulsive.Intertek.LIMSService")]
    public class AddResult
    {
    	[DataMember()]
    	public string ErrorMessage;
    	[DataMember()]
    	public bool ResultStatus;
    	[DataMember()]
    	public string Result;
    }
    
    [DataContract(Namespace = "")]
    public class AddOrderResult : AddResult
    {
    
    	[DataMember()]
    	public Order Order;
    }
    	
    [DataContract(Namespace = "")]
    public class Order
    {
    
    	[DataMember()] 
    	public int Kto;
    
    
    	[DataMember()]
    	public string LIMSIdentifier;
    
    	[DataMember()]
    	public string Matchcode;
    
    	[DataMember()]
    	public int OfficeLineHandle;
    
    	[DataMember()]
    	public bool OverruleCreditCheck;
    }
    }
