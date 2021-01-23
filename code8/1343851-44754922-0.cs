    public void Convert2Json() 
            { 
                try 
                { 
                    if (FileUpload1.PostedFile.FileName != string.Empty) 
                    { 
                        string[] FileExt = FileUpload1.FileName.Split('.'); 
                        string FileEx = FileExt[FileExt.Length - 1]; 
                        if (FileEx.ToLower() == "csv") 
                        { 
                            string SourcePath = Server.MapPath("Resources//" + FileUpload1.FileName); 
                            FileUpload1.SaveAs(SourcePath); 
                            string Destpath = (Server.MapPath("Resources//" + FileExt[0] + ".json")); 
     
                            StreamWriter sw = new StreamWriter(Destpath); 
                            var csv = new List<string[]>(); 
                            var lines = System.IO.File.ReadAllLines(SourcePath); 
                            foreach (string line in lines) 
                                csv.Add(line.Split(',')); 
                            string json = new 
                                System.Web.Script.Serialization.JavaScriptSerializer().Serialize(csv); 
                            sw.Write(json); 
                            sw.Close(); 
                            TextBox1.Text = Destpath; 
                            MessageBox.Show("File is converted to json."); 
                        } 
                        else 
                        { 
                            MessageBox.Show("Invalid File"); 
                        } 
     
                    } 
                    else 
                    { 
                        MessageBox.Show("File Not Found."); 
                    } 
                } 
                catch (Exception ex) 
                { 
                    MessageBox.Show(ex.Message); 
                } 
            }
