    
    //This will be the resulting list of arrays
    var fileArrayList = new List<string[]>();
    var filereader = new System.IO.StreamReader("yourfile");
    var tmpArr = new List<string>();
    var line = "";
    while((line = filereader.ReadLine()) != null)
    {
       if(String.IsNullOrEmpty(line){
           //put this array to our list
           fileArrayList.Add(tmpArr.ToArray());
           //clean the temp one
           tmpArr.Clear();
       }else
       {
           tmpArr.Add(line);
       }
    }
    //add the last entry
    fileArrayList.Add(tmpArr.ToArray());
    tmpArr = null;
    //close the stream
    filereader.Close();
