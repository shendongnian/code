        public static void ReadMultiClassCsv()
        {
            var class1Data = new List<Class1>();
            var class2Data = new List<Class2>();
            using (StreamReader reader = File.OpenText(@"C:\filename.csv"))
            using (var csvReader = new CsvReader(reader))
            {
                //1.  You manually read the csv file row by row
                while (csvReader.Read())
                {
                    var discriminator = csvReader.GetField<string>(0);
                    //2.  Inspect the first column for the discriminator that will indicate that you need to map to a Class object.
                    if (discriminator == "D")
                    {
                        var classType = csvReader.GetField<string>(1);
                        //3.  Inspect the second column for the class to map to.
                        switch (classType)
                        {
                            //4.  Map the entire row to that given class.
                            case "Class1":
                                class1Data.Add(csvReader.GetRecord<Class1>());
                                break;
                            case "Class2":
                                class2Data.Add(csvReader.GetRecord<Class2>());
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
