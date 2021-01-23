     List<List<List<string>>> nestedList = new List<List<List<string>>>
                                           {
                                              new List<List<string>> {new List<string> {"Hello "}, new List<string> {"World "}},
                                              new List<List<string>> {new List<string> {"Goodbye "}, new List<string> {"World ", "End "}}
                                          };
    Console.WriteLine(String.Join(" ",Flatten(nestedList))); 
