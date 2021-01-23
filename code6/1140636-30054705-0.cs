        public class kid
        {
            public int age;
            public String name;
            public List<String> toys;
    
            public string ApiCustomView
            {
                get
                {
                    Dictionary<string, string> result = new Dictionary<string, string>();
                    result.Add("age", age.ToString());
                    result.Add("name", name);
                    for (int ii = 0; ii < toys.Count; ii++)
                    {
                        result.Add(string.Format("toy_{0}", ii), toys[ii]);
                    }
                    return result.ToJSON();
                }
            }
        }
