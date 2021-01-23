    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();;
        if (null != line)
        {
           List<string> listTime = new List<string>();
           string[] digits = line.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
           foreach (string digit in digits)
           {
              string[] eachdigit = digit.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
              //dictHH.Add(eachdigit[0], eachdigit[1] + " " + eachdigit[2]);
              list.Add(eachdigit[0]+ eachdigit[1] + " " + eachdigit[2]);
           }         
           foreach (var c in list.OrderBy(x => x))
              Console.WriteLine(c);
          }          
    }
