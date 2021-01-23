       private static bool fileAccessible(string filePath) {
           try
            {
                return  File.Exists(filePath);
             }
           catch (Exception ex)
           {
    //handle exception
           }
        }
