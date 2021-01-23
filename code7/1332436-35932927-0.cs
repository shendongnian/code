        int sum = 0;
        int sub = 0;
        string numbers = "1 + 1,2 - 1,3 + 3";
        string num="";
        int count = 1;
        string[] words = numbers.Split(',');
        foreach (string word in words)
        {
           if(word.Contains("+"))
           {
           
            string[] addition=word.Split('+');
            foreach(string value in addition)
            {
                sum += Convert.ToInt32(value);
            }
            num=num+sum+",";
            sum = 0;
           }
            if(word.Contains("-"))
            {
                string[] subtraction = word.Split('-');
                foreach (string value in subtraction)
                {
                if(count==1)
                {
                    sub = Convert.ToInt32(value);
                    count++;
                }
                else
                {
                    sub = sub-Convert.ToInt32(value);
                }
                }
                 num=num+sub+",";
                 sub = 0;
            }
        }
        Console.WriteLine(num);
