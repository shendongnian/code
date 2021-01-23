    using  Microsoft.VisualBasic.FileIO;
    public List<MyVal> GetValues() {
        var path = "path/to/file";
        var list = new List<MyVal>();
        using(var csvReader = new TextFieldParser(path)) {
            csvReader.TextFieldType = FileIO.FieldType.Delimited;
            csvReader.SetDelimiters("--");
            while(!csvReader.EndOfData) {
                var currentRow = csvReader.ReadField();
                if(csvReader.LineNumber != 1)
                    list.Add(new MyPoco() { Code = currentRow[0], Name = currentRow[1], Req = currentRow[2], Country = currentRow[3]});
                }
            }
        }
    }
