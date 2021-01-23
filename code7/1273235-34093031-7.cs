 			using (StreamReader sr = new StreamReader(sourceFileName))
            {
				List<Model> modelList = new List<Model>();
                string headerLine = sr.ReadLine();
                string currentLine;
                for (int i = 0; i < strArray.Length; i++)
                {       
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                     string[] strArray = currentLine.Split(',');
					 Model myModel = new Model();
					
					 switch (i)
                        {
                            case 0: myModel.InvoiceNumber =  = strArray[i]; break;
                            case 1: myModel.InvoiceHeaderId = strArray[i]; break;
						}
                    }
				}
             modelList.Add(myModel);
            }
				
			}
			
