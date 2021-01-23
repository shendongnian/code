    [UserCodeCollection]
    	public class UserCodeCollectionDemo
    	{
    		
    		[UserCodeMethod]
    		public static void ConvertXmlToCsv()
    		{
    			System.IO.File.Delete("E:\\Ranorex_test.csv");
    			XDocument doc = XDocument.Load("E:\\lang.xml");
    			string csvOut = string.Empty;
    			StringBuilder sColumnString = new StringBuilder(50000);
    			StringBuilder sDataString = new StringBuilder(50000);
    			foreach (XElement node in doc.Descendants(GetServerLanguage()))
    			{
    				foreach (XElement categoryNode in node.Elements())
    				{
    					foreach (XElement innerNode in categoryNode.Elements())
    					{
    						//"{0}," give you the output in Comma seperated format.
    						string sNodePath = categoryNode.Name + "_" + innerNode.Name;
    						sColumnString.AppendFormat("{0},", sNodePath);
    						sDataString.AppendFormat("{0},", innerNode.Value);
    					}
    				}
    			}
    			if ((sColumnString.Length > 1) && (sDataString.Length > 1))
    			{
    				sColumnString.Remove(sColumnString.Length-1, 1);
    				sDataString.Remove(sDataString.Length-1, 1);
    			}
    			string[] lines = { sColumnString.ToString(), sDataString.ToString() };
    			System.IO.File.WriteAllLines(@"E:\Ranorex_test.csv", lines);
    		}
    }
