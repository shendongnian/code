    var fileArrayList = new List<string[]>();
    filereader = new System.IO.StreamReader("yourfile");
    var tmpArr = new List<string>();
    while((line = filereader.ReadLine()) != null)
    {
       if(line.IsNullOrEmpty(){
           fileArrayList.Add(tmpArr.ToArray());
           tmpArr.Clear();
       }else
       {
           tmpArr.Add(line);
       }
    }
    filereader.Close();
