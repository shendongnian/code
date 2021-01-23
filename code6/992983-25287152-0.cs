    XmlTextReader reader = new XmlTextReader(saveurl);
									List<string> values = new List<string>();
									while (reader.Read())
										{
										switch (reader.NodeType)
											{
												case XmlNodeType.Text:
												values.Add(reader.Value);
												break;
						                	
											} //switch case ends
										} // while loop ends
