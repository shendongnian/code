    public static void Create(string myName, string myValue, string myComment)
    {
        ResXResourceWriter resxWriter;
        try
        {
            resxWriter = new ResXResourceWriter(@"D:\Validator_Tool\resx\resx\myres.resx");
            
            // --- Use this if it looks more readable and convenient ---
            // var node = new ResXDataNode(myName, myValue);
            // node.Comment = myComment;
            // resxWriter.AddResource(node);
            resxWriter.AddResource(new ResXDataNode(myName, myValue)   
            {
                Comment = myComment
            });
            resxWriter.Close();
        }
        catch (FileNotFoundException caught)
        {
            MessageBox.Show("Source: " + caught.Source + " Message: " + caught.Message);
        }
    }
