    private bool LoadFaceRecognition(string Training_Folder, string TrainedFaces) { 
    
    	  if (File.Exists(Training_Folder + TrainedFaces + "/TrainedLabels.xml"))
    		{
    			try
    			{
    				Names_List_Faces.Clear();
    				trainingImages_Faces.Clear();
    				using (FileStream filestream = File.OpenRead(Training_Folder + TrainedFaces + "/TrainedLabels.xml"))
    				{
    	
    					long filelength = filestream.Length;
    					byte[] xmlBytes = new byte[filelength];
    					filestream.Read(xmlBytes, 0, (int)filelength);
    					filestream.Close();
    		
    					using (MemoryStream xmlStream = new MemoryStream(xmlBytes))
    					{
    						using(XmlReader xmlreader = XmlTextReader.Create(xmlStream))
    						{
    			
    							while (xmlreader.Read())
    							{
    								if (xmlreader.IsStartElement())
    								{
    									switch (xmlreader.Name)
    									{
    										case "NAME":
    											if (xmlreader.Read())
    											{
    												//Names_List_ID.Add(Names_List.Count); //0, 1, 2, 3....
    												Names_List_Faces.Add(xmlreader.Value.Trim());
    												NumLabels_Faces += 1;
    											}
    											break;
    										case "FILE":
    											if (xmlreader.Read())
    											{
    												//PROBLEM HERE IF TRAININGG MOVED
    												trainingImages_Faces.Add(new Image<Gray, byte>(Training_Folder + "/TrainedFaces//" + xmlreader.Value.Trim()));
    				
    											}
    											break;
    									}
    								}
    							}
    							ContTrain_Faces = NumLabels_Faces;
    							if (trainingImages_Faces.ToArray().Length != 0)
    							{
    								recognizer_Faces = new EORecognizer(trainingImages_Faces.ToArray(), Names_List_Faces.ToArray(), Eigen_Threshold, ref termCrit_Faces);
    								return true;
    				
    							}
    							else return false;
    						}
    					}
    				}
    			}
    			catch (Exception ex)
    			{
    				Error = ex.ToString();
    				return false;
    			}
    		}
    		else return false;
    	}
