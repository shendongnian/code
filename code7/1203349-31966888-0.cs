           string input = "112233 445566 778899 101010";
           string[] dates = input.Split(' ');
           
           foreach (string date in dates){
               Console.WriteLine(date);
               string result = date.Substring(0, 2) + '-' + date.Substring(2, 2) + "-" + date.Substring(4, 2);
               Console.WriteLine(result);
           }
