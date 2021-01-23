    public class MyClass{
    /// <summary>
    /// Keeps the file name
    /// </summary>
    public string FileName { get; set; }
    /// <summary>
    /// Action to write the file
    /// </summary>
    /// <returns>Returns true if the info. was wrote into the file.</returns>
    public bool WriteToFileSucceed()
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
...
    public void button1_Click(object sender, EventArgs e){
    MyClass myClass = new MyClass();
    myClass.FileName = @"C:\crypt\crypt.txt";
    if(myClass.WriteToFileSucceed())
    {
        MessageBox.Show("Success, managed to write to the file");
    }
    else
    {   
        MessageBox.Show("Ops! Unable to write to the file.");
    }}
