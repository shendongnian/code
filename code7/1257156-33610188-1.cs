    public class MyClass{
    /// <summary>
    /// Keeps the file name
    /// </summary>
    public string FileName { get; set; }
    /// <summary>
    /// Action to write the file
    /// </summary>
    /// <returns>Returns true if the info. was wrote into the file.</returns>
    public bool WriteToFile()
    {        
        try
        {
            using (System.IO.StreamWriter WriteToFile = new System.IO.StreamWriter(FileName))
            {
                WriteToFile.Write(text);
                WriteToFile.Close();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }}
