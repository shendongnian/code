        TextFieldParser parser = new TextFieldParser(@"C:\Users\thomoe\Desktop\SMSvarsel\nsdatabase.csv");
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(";");
        List<MyStruct> myData = new List<MysTruct>();
        while (!parser.EndOfData)
        {
            //Process row
            string[] fields = parser.ReadFields();
            myData.Add(new MyStruct()
            {
                NS = fields[0],
                Sek = fields[1],
                Radial = fields[2]
            });            
        }
