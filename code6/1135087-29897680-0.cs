            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Public\TestFolder\EXPORT.TXT");
            while (file.Peek() != -1)
            {
                line = file.ReadLine();
                string test1;
                string readdate;
                test1 = line.Substring(0, 8);//1
                FullName = line.Substring(8, 20);//2
                Address = line.Substring(28, 20);//3
                ModuleNumber = line.Substring(48, 10);//4
                test1 = line.Substring(58, 4);//5
                ReadType = line.Substring(62, 1);//6
                Service = line.Substring(63, 1);//7
                test1 = line.Substring(64, 1);//8
                test1 = line.Substring(65, 2);//9
                test1 = line.Substring(67, 9);//10
           }
