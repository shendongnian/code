    string[] listCountAnwser = {"1", "2", "3"};
    List<string> listCountAnwsers = new List<string>(listCountAnwser);
    for (int i = 0; i < listCountAnwsers.Count; i++)
    {
        if (Int32.Parse(listCountAnwsers[i]) < Int32.Parse(listCountAnwsers[i+1]))
        {
            listCountAnwsers.Remove(listCountAnwser[i]);
         }
     }
