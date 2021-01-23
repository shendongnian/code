    string item1 = "1 Johannes 1:12";
    string item2 = "1 Johannes 1:1";
    string fullText= "randomtext 1 Johannes 1:12 randomtext";
    string comparedValue =fullText.Replace(" ", string.Empty)
    string result ;
    List<string> sentences = new List<string>();
    sentences.add(item1.Replace(" ", string.Empty));
    sentences.add(item2.Replace(" ", string.Empty));
    foreach(string item in sentences){
          if(comparedValue .Contains(item){
          result = item;
       break;
          }
    }
