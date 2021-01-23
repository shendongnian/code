	using System;
	using System.Diagnostics;
	using System.Xml; 
	
	namespace XMLNet
	{
		class Program
		{
			public static void Main(string[] args)
			{
		        using (Process cmd = new Process())
		        {	            
		            cmd.StartInfo.FileName = "cmd.exe";
		            cmd.StartInfo.Arguments = "/c Net View /all";
		
		            cmd.StartInfo.CreateNoWindow = true;
		            cmd.StartInfo.UseShellExecute = false;
		            cmd.StartInfo.RedirectStandardOutput = true;
		
		            cmd.Start();
		
		            using(XmlTextWriter writer = new XmlTextWriter("net.xml", System.Text.Encoding.UTF8))
		            {
                        int _id = 0;
		            	
                        writer.WriteStartDocument(true);
			            writer.Formatting = Formatting.Indented;
			            writer.Indentation = 2;
		            	writer.WriteStartElement("Net_View");
		            	
			            while (!cmd.StandardOutput.EndOfStream)
			            {
			                string line = cmd.StandardOutput.ReadLine();
			
			                if (line == "There are no entries in the list.")
			                	return;
			                if (!String.IsNullOrWhiteSpace(line))
			                {
			                	if (line.StartsWith(@"\\"))
			                	{
                                    string aux = line.TrimStart('\\').TrimEnd();
                                    writer.WriteStartElement("result");
                                    writer.WriteAttributeString("id", _id.ToString());
                                    writer.WriteString(aux);
                                    writer.WriteEndElement();
                                    _id++;
			                	}
			                }
			            }
			            
			            writer.WriteEndElement();
			     		writer.WriteEndDocument();
	            		writer.Close();
	            		
	            		Console.WriteLine("Done!");
		            }
		        }
		    }
		}
	}
