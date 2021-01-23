    using System;
    using System.Data.OleDb;
    using System.Xml;					
    using System.Data.Common;
    public class Program
    {
    
        	public static void Main()
        	{
        		 string connectionString ="";
          		XmlDocument doc = new XmlDocument();
        		using (OleDbConnection connection = new OleDbConnection(connectionString))
        		{
        			connection.Open();
        		    OleDbCommand command = new OleDbCommand("Select * FROM [Sheet1$] ", connection);
    
                 XmlElement root = doc.CreateElement("node");
                 doc.AppendChild(root);
            	using (DbDataReader dr = command.ExecuteReader())
            	{
                	while (dr.Read())
                	{
            
                #region Field Matrices
                // Field Matrix
                string r01  = dr.GetValue(0).ToString();
                string r11  = dr.GetValue(1).ToString();
                string r21  = dr.GetValue(2).ToString();
        
        
                XmlElement subnode = doc.CreateElement("subnode");
                root.AppendChild(subnode);
                XmlAttribute name = doc.CreateAttribute("name");
                name.Value = r01;        
                subnode.Attributes.Append(name);
                XmlAttribute sum = doc.CreateAttribute("sum");
                sum.Value = r11  + r21;        
                subnode.Attributes.Append(sum);
            	}
        	}
		}
        doc.Save(Console.Out);
	}
