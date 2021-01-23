		 public string GetVersion(string tableName)
				{
					XElement xelement = XElement.Load(_xmlFileName);
					var table = xelement.Elements("Table").FirstOrDefault(m => (string)m.Attribute("Name") == tableName);
					if (table != null)
					{
						var version = (string)table.Attribute("Version");
						Console.WriteLine(" {0} {1}", tableName, version);
						return version;
					}
					return string.Empty;
				}
