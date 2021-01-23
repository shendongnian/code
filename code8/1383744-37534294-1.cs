    using System.Text.RegularExpressions; //regex
    using System.IO; //File reading
    
    #region //Return the count of words in a file
    public int wordamount(string filename) 
    {
         return Regex.Matches(File.ReadAllText(filename), @"\w+|\w+\'\w+").Count; //Match all the alphanumeric characters, and or with commas
    }
    #endregion
