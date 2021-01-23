    public class CsvFileUserCredentialsValidator 
    {
        private readonly string _filePath;
        public CsvFileUserCredentialsValidator(string filePath)
        {
            _filePath = filePath;
        }
        public bool UserCredentialsAreValid(string userName, string password)
        {
            //Open the file. Because of the "using" block the StreamReader will
            //always get disposed regardless of how the function returns. That
            //means the file won't be left open.
            using (var streamReader = new StreamReader(_filePath))
            {
                //Continue while we're not at the end of the file
                while (!streamReader.EndOfStream)
                {
                    //Read a line
                    var line = streamReader.ReadLine();
                    //If the line is empty skip to the next line.
                    if(string.IsNullOrEmpty(line)) continue;
                    //Split it by comma.
                    var split = line.Split(',');
                    //If there aren't exactly two values then something isn't right
                    //with this line. Ignore it and go to the next line.
                    if (split.Length != 2) continue;
                    //Compare the two values to see if they match the user and pw.
                    //Username isn't case-sensitive but password is.
                    //If it's a match return true. The username and password are valid.
                    //Because we're returning true we won't read any more from the file.
                    if (string.Equals(split[0], userName, StringComparison.OrdinalIgnoreCase) 
                        && string.Equals(split[1], password, StringComparison.Ordinal))
                        return true;
                }
                //We went through the whole file without a match. Return false.
                return false;
            }
        }
    }
    var validator = new CsvFileUserCredentialsValidator(pathToYourCsvFile);
    var isValid = validator.UserCredentialsAreValid(username, password);
