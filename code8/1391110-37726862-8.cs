    string output = string.Empty;
    string error = string.Empty;
    //If you want to read the Output of that argument
    using (StreamReader streamReader = process.StandardOutput)
          {
              output = streamReader.ReadToEnd();
          }
    //If you want to read the Error produced by the argument *if any*
    using (StreamReader streamReader = process.StandardError)
          {
              error = streamReader.ReadToEnd();
          }
