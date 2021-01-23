     public  class dd_internals
        {
            private static dd_internals instance;
            public static dd_internals singleInstance;
    
            private dd_internals() { }
    
            public static dd_internals Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new dd_internals();
                    }
                    return instance;
                }
            }
    
            public int current_process_index;
            public class process_class
            {
                public string process_name;
                public List<string> parm_list;
                public List<string> var_list;
                public List<string> statements;
            }
            public List<process_class> process_list = new List<process_class>();
        }
