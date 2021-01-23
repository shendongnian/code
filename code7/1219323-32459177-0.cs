            string tempFile = System.IO.Path.GetTempFileName();
            System.IO.File.WriteAllText(tempFile, @"A;C\r\n\TestA1;TestC1\r\nTestA2;TestC1");
            var engine = new FileHelperEngine<TestRecord>();
            var records = engine.ReadFile(tempFile, 1);
            // Get the header text from the file
            var headerFile = engine.HeaderText.Replace("\r", "").Replace("\n", "");
            // Get the header from the engine record layout
            var headerFields = engine.GetFileHeader();
            // Test fixed string against column as column could be null and Debug.Assert can't use .Equals on a null object!
            string column = records[0].C;
            Debug.Assert("TestC1".Equals(column), "Test 1 - Column C does not equal 'TestC1'");  //Fails, returns ""
            // Test fixed string against column as column could be null and Debug.Assert can't use .Equals on a null object!
            column = records[0].B;
            Debug.Assert(!"TestC1".Equals(column), "Test 1 - Column B does equal 'TestC1'");  //True, but that was not what I wanted
            // Create a new engine otherwise we get some random error from Dynamic.Assign once we start removing fields
            // which is presumably because we have called ReadFile() before hand.
            engine = new FileHelperEngine<TestRecord>();
            if (headerFile != headerFields)
            {
                var fieldHeaders = engine.Options.FieldsNames;
                var fileHeaders = headerFile.Split(';').ToList();
                // Loop through all the record layout fields and remove those not found in the file header
                for (int index = fieldHeaders.Length - 1; index >= 0; index--)
                    if (!fileHeaders.Contains(fieldHeaders[index]))
                        engine.Options.RemoveField(fieldHeaders[index]);
            }
            headerFields = engine.GetFileHeader();
            Debug.Assert(headerFile == headerFields);
            var records2 = engine.ReadFile(tempFile);
            // Test fixed string against column as column could be null and Debug.Assert can't use .Equals on a null object!
            column = records2[0].C;
            Debug.Assert("TestC1".Equals(column), "Test 2 - Column C does not equal 'TestC1'");  //Fails, returns ""
            // Test fixed string against column as column could be null and Debug.Assert can't use .Equals on a null object!
            column = records2[0].B;
            Debug.Assert(!"TestC1".Equals(column), "Test 2 - Column B does equal 'TestC1'");  //True, but that was not what I wanted
            Console.WriteLine("Seems to be OK now!");
            Console.ReadLine();
