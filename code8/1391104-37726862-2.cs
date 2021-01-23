    string output = string.Empty;
    string error = string.Empty;
    using (StreamReader streamReader = process.StandardOutput)
          {
              output = streamReader.ReadToEnd();
          }
 
    using (StreamReader streamReader = process.StandardError)
          {
              error = streamReader.ReadToEnd();
          }
