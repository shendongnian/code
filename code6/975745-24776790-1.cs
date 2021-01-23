    
    //This will be the resulting list of arrays
    var fileArrayList = new List<string[]>();
    var filereader = new System.IO.StreamReader("yourfile");
    var tmpArr = new List<string>();
    while((line = filereader.ReadLine()) != null)
    {
       if(line.IsNullOrEmpty(){
           //put this array to our list
           fileArrayList.Add(tmpArr.ToArray());
           //clean the temp one
           tmpArr.Clear();
       }else
       {
           tmpArr.Add(line);
       }
    }
    filereader.Close();
