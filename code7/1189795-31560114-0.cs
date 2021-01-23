    Dictionary<string,int> NameOcur=new Dictionary<string,int>();
    ...
     while (!reader.EndOfStream)
        {
            //read line from file
            line = reader.ReadLine().ToLower();
    
            //split values
            csvArray = line.Split(',');
            if (NameOcur.ContainsKey(csvArray[0]))
            {
              ///Name exists in Dictionary increase count
               NameOcur[csvArray[0]]++;
            }
            else
            {
              //Does not exist add with value 1
               NameOcur.Add(csvArray[0],1);
            }
         }
