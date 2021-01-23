    try
            {
                if (//file does not exist)
                   File.WriteAllText("E:\\test.txt", "welcome");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
