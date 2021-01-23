 			using (StreamReader sr = new StreamReader(sourceFileName))
            {
				List<Model> modelList = new List<Model>();
                string headerLine = sr.ReadLine();
                string currentLine;
                while ((currentLine = sr.ReadLine()) != null)
                {
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
			
