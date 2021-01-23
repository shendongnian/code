    using System.Text.RegularExpressions; //regex
    using System.IO; //File reading
    
    #region //Return the count of words in a file
    public int wordamount(string filename) 
    {
         string file = File.ReadAllText("path.txt"); //Load the text file
         return Regex.Matches(file, @"\w+|\w+\'\w+").Count; //Match all the alphanumeric characters, and or with commas
    }
    #endregion
