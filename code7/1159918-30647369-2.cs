    static void Main(string[] args)
    {
        string line;
        try
        {
            using (StreamWriter sw = new StreamWriter("C:\\writetest\\writetest.txt"))
            {
                string mydirpath = "C:\\chat\\";
                string[] txtFileList = Directory.GetFiles(mydirpath, "*.txt");
                foreach (string txtName in txtFileList)
                {
                    string spart = ".prt";
                    string sam = " AM";
                    string spm = " PM";
                    string sresult = "TEST RESULT: ";
                    string svelocity = "MEASURED VELOCITY: ";
                    string part = string.Empty;
                    string date = string.Empty;
                    string result = string.Empty;
                    string velocity = string.Empty;
                    using (StreamReader sr = new StreamReader(txtName))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (!string.IsNullOrEmpty(line) && line.Trim().Length != 0)
                            {
                                if (line.Contains(sam) || line.Contains(spm))
                                {
                                    // Every new date means a new record. If you already have data for a record, first write it.
                                    if (if (!string.IsNullOrEmpty(date) && date.Trim().Length != 0 && !string.IsNullOrEmpty(velocity) && velocity.Trim().Length != 0))
                                    {
                                        int I = 2;
                                        string[] x = new string[I];
                                        x[0] = date;
                                        x[1] = velocity;
                                        sw.WriteLine(x[0] + "," + x[1]);
                                    }
                                    // Then reset data to prepare it for a new record
                                    part = string.Empty;
                                    result = string.Empty;
                                    velocity = string.Empty;
                                    date = line;
                                }
                                if (line.Contains(spart))
                                {
                                    part = line;
                                }
                                if (line.Contains(sresult))
                                {
                                    result = line;
                                }
                                if (line.Contains(svelocity))
                                {
                                    velocity = line;
                                }
                            }
                        }
                    }
                    // After last record you still have some data to write
                    if (if (!string.IsNullOrEmpty(date) && date.Trim().Length != 0 && !string.IsNullOrEmpty(velocity) && velocity.Trim().Length != 0))
                    {
                        int I = 2;
                        string[] x = new string[I];
                        x[0] = date;
                        x[1] = velocity;
                        sw.WriteLine(x[0] + "," + x[1]);
                    }
                }
            }
        }
        catch
        {
        }
    }
