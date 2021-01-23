    class  testObject
        {
            public string s;
            public virtual void testFunction()
            {
                string b = s;
            }
        }
    
        class testObject2 : testObject
        {
            public string m;
            public override void testFunction()
            {
                string x = m;
    
            }
        }
