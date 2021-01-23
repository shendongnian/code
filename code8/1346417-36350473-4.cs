    switch (a){
        case 0: //string case
          Console.WriteLine(x + "*");
          break;
        case 1: //int case
          Console.WriteLine((Convert.ToInt32(x) + 1).ToString());
          break;
        case 2: //double case
          Console.WriteLine((Convert.ToDouble(x) + 1).ToString());
          break;
        case 3: //int or double case
          Console.WriteLine((Convert.ToInt32(x) + 1).ToString());
          break;
    }
