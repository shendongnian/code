    using (StreamReader sr = File.OpenText("txtFile.txt")) // Mention the path,if the file is not in application folder.
             
       {
                string str = String.Empty;<br/>
                while ((str = sr.ReadLine()) != null)
                {
                    string[] item = str.Split(' ');
                    SqlConnection con = new SqlConnection(str);
                    SqlCommand cmd = new SqlCommand();
                    string query1 = "INSERT INTO [dbo].[TEMP_AUTO]([ID],[NAME]) VALUES ('" + item[0] + "', '" + item[1]  + "')";
                    // Do remain part<br/>
                }
            }
