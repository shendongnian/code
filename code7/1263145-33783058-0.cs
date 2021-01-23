        const string FILE_NAME = "save.txt";
        using (FileStream fs = new FileStream(FILE_NAME, FileMode.Create))
                {
                    // Create the writer for data.
                    using (StreamWriter w = new StreamWriter(fs))
                    {
                        // Write data to save.txt
                        w.WriteLine(
                            Convert.ToString( MyCheckBox.Enabled )
                            );
                    }
                }
