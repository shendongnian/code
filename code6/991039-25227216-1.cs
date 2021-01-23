    finally
    {
    
        string InputLine, tempSTR, productname, strQuantity, strUnitprice;
        StreamReader ReadFile = new StreamReader(UploadFile);
        string fileContest = ReadFile.ReadToEnd();
        string[] splitedText = fileContest.Split(',');
        int j = 0;
        for(int i = 0;i < splitedText.Length , i++)
        {
          switch(j)
          {
             case 0:
              j++;
              b.NAME = splitedText[i];
             break;
             case 1:
              j++;
              b.QUANTITY = int.Parse(splitedText[i]);
             break;
             case 2:
              j=0;
              b.UNITPRICE = int.Parse(splitedText[i]);
              b.AddProducts();
             break;
          }
        }
        GridView1.DataSource = b.ViewProducts();
        GridView1.DataBind();
    
    }
