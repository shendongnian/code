       public static string method1(string a, string b)
        {
            return a + b;
        }
       public static int method2(int id1, string id2, string id3)
        {
            return 0;
        }
      var result1 = InvokeFunction<string>(() => method1("val1", "val2"));
      var result2 = InvokeFunction<int>(() => method2(123, "val1", "val2"));
