                    //Started from array of strings - (you may read from file and put in the arrays)
        
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string[] text1 = System.IO.File.ReadAllLines(path + "test.txt");
                    string[] text2 = System.IO.File.ReadAllLines(path + "test2.txt");
                    text2[0] = text2[0] + text1.Where(x => x.Split('=')[0] == "Output").FirstOrDefault().Split('=')[1];
                    text2[1] = text2[1] + text1.Where(x => x.Split('=')[0] == "Licfile").FirstOrDefault().Split('=')[1];    
                    text2[2] = text2[2] + "false";
                    text2[3] = text2[3] + "true";
        
                    //Now the result variable will contain the final text, you can write in a file.
                    string result = string.Join(Environment.NewLine, text2);
            
