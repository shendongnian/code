    List<string> sentences = new List<string>();
    sentences.Add("1 Johannes 1:12");
    sentences.Add("1 Johannes 1:1");
    string fulltext = "randomtext 1 Johannes 1:12 randomtext";
    sentences.Sort();
    foreach(string item in sentences)
    {
       if(fulltext.Contains(item))
       {
          //expect the result to be 1 Johannes 1:12, but the result is 1 Johannes 1:1 
          //do operation
          Console.WriteLine(item);//try it in a Console App you will get the results in the order that you are expecting
       }
    }
    Console.Read();
