    using System.IO;
    using System.Text;
    int counter = 0;
    string line = String.Empty;
    StringBuilder newString = new StringBuilder();
    StreamReader file = new StreamReader("c:\\test.txt");
    while((line = file.ReadLine()) != null)
    {
    	newString.Append(line + ",");
    }
    file.Close();
    newString.ToString().TrimEnd(',');
