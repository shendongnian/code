    If you still have not found your answer then try this (a bit old school but it worked for me)
    
    public class Common
    	{
    		public Common()
    		{
    		}
    //		public static string GetXML()
    //		{
    //			return @"C:\MyLocation\Connections.xml";
    //		}
    		public static string GetXMLconn(string strConn)
    		{
    			string xmlConStr = "";
    			//
    			string XMLconn = @"C:\Mylocation\Connections.xml"; 
    
    			// Get the Connection String from the XML file.
    			XmlTextReader textReader  = new XmlTextReader(XMLconn);
    			textReader.Read();
    			while (textReader.Read())
    			{
    				// Read the currect element in the loop
    				textReader.MoveToElement();
    				// If the element name is correct then read and assign the connection string
    				if (textReader.Name == strConn)
    				{
    					xmlConStr = textReader.ReadString();
    				}
    			}
    			textReader.Close();
    
    			return xmlConStr;
    
    		}
	}
