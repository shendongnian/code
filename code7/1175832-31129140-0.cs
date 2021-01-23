    using (StreamWriter file = new StreamWriter(fileName, false))
            { //Opens the file and creates a Stream, closes the file once finished.
                file.WriteLine("teststart");
                for (int i = 0; i < checkBoxes.Count; i++)
                {
                    //file.WriteLine("test" + i);
                    if (checkBoxes[i].Checked)
                        file.WriteLine("t");
                    else
                        file.WriteLine("f");
                }
                file.WriteLine("testend");
            }
