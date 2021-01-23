    class Test
    {
        public string s1(string val) { return val; }
    
        public void DoSome(out string result)
        {
            string localResult;
            while(some code here)
            {
                localResult = s1(result1 + result2);
                // And other manipulations to localResult...
            }
            result = localResult;
        }
    }
	
