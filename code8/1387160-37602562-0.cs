   		private static void getNodes(string filePath)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(filePath);
			var productNodes = xmlDoc.SelectNodes("//Product");
			if (productNodes != null)
			{
				foreach (XmlNode product in productNodes)
				{
					var childNodes = product.ChildNodes;
					foreach (XmlNode child in childNodes)
					{
						if (child.Name == "ProductName")
						{
							Console.WriteLine(child.InnerText);
						}
						else if (child.Name == "Usages")
						{
							var childNodes2 = child.ChildNodes;
							foreach (XmlNode child2 in childNodes2)
							{
								if (child2.Name == "Usage")
								{
									var childNodes3 = child2.ChildNodes;
									foreach (XmlNode child3 in childNodes3)
									{
										if (child3.Name == "Specs")
										{
											var childNodes4 = child3.ChildNodes;
											foreach (XmlNode child4 in childNodes4)
											{
												foreach (XmlNode a in child4.Attributes)
												{
													Console.WriteLine($"  {a.InnerText}");
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			Console.ReadLine();
		}
