    //--> indexes into parsed line...
    const int RegNo = 0;
    const int AcctHolder = 2;
    const int Amount = 4;
    const int AcctNo = 6;
    //--> ...etc.
    using Microsoft.VisualBasic.FileIO;
    //...
    List<object[]> fileContent = new List<object[]>();
    using (FileStream reader = File.OpenRead(ofd.FileName))
    using (TextFieldParser parser = new TextFieldParser(reader))
    {
      parser.TextFieldType = FieldType.FixedWidth;
      parser.SetFieldWidths
      (
         6  1, //--> width of RegNo, width of ignored comma
        10, 1, //--> width of AcctHolder, width of ignored comma
        10, 1, //--> width of Amount, width of ignored comma
        13, 1, //--> etc...
         6, 1, 
         6, 1, 
         2, 1,
         1
      );
      while (!parser.EndOfData)
      {
        object[] line = parser.ReadFields();
        fileContent.Add(line);
        lstRegNo.Add( line[ RegNo ].ToString( ));
        lstAccHolder.Add(line[ AcctHolder ].ToString().Replace(',', ' '));
        lstAmount.Add(line[ Amount ].ToString().Trim().Replace(',', ' '));
        lstAccNo.Add(line[ AcctNo ].ToString().Trim());
        //--> etc...
      }
    }
