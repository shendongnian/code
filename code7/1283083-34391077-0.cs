            string name = "test_test1_test2_test3";
            int pos = name.LastIndexOf("_");
            while (pos > -1)
            {
                string test_string = name.Substring(pos + 1);
                Console.WriteLine(test_string);
                pos = name.LastIndexOf("_", pos - 1);
            }
