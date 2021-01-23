    private void ImportFiles()
    {
        DataTable dt = GetFixedFileSpecsFromDB(layoutName); //Get the specs
        //Create Dynamic class based on Specs above
        FixedLengthClassBuilder cb = GetSpecClass(dt);
        //Create FileHelpers engine instance
        FileHelperEngine engine = new FileHelperEngine(cb.CreateRecordClass());
        //Read file data into Data table
        DataTable dtImportData = engine.ReadFileAsDT(ImportFilePath);
    }
    //Method to create the Fixed lentgh dynamic class
     public static FixedLengthClassBuilder GetSpecClass(DataTable dt)
        {
            string className = "ImportSpecifications";
            FixedLengthClassBuilder cb = new FixedLengthClassBuilder(className);
            //Loop thru each field and prepare the class
            foreach (DataRow dr in dt.Rows)
            {
                int fieldLength = Convert.ToInt32(dr.Field<decimal>("FieldLength"));
                switch (dr["FieldDataType"].ToString())
                {
                    case "String":
                        cb.AddField(dr.Field<string>("FieldName"), fieldLength, typeof(string));
                        cb.LastField.FieldNullValue = string.Empty;
                        cb.LastField.TrimMode = FileHelpers.TrimMode.Both;
                        break;
                    case "Date":
                        cb.AddField(dr.Field<string>("FieldName"), fieldLength, typeof(DateTime));
                        cb.LastField.FieldNullValue = string.Empty;
                        break;
                    case "Integer":
                        cb.AddField(dr.Field<string>("FieldName"), fieldLength, typeof(int?));
                        //cb.LastField.FieldNullValue = 0;
                        break;
                    case "Long Integer":
                        cb.AddField(dr.Field<string>("FieldName"), fieldLength, typeof(long));
                        cb.LastField.FieldNullValue = 0;
                        break;
                    case "Decimal":
                        cb.AddField(dr.Field<string>("FieldName"), fieldLength, typeof(decimal?));
                        //cb.LastField.FieldNullValue = 0;
                        break;
                    default:
                        break;
                }
            }
            return cb;
        }
