        string text = "";
        sampleDelegate s1 = delegate()
        {
             if(!string.IsNullOrEmpty(text)) 
             {
                 SampleMethod1();
             }
             else
             {
                 SampleMethod2();
             }
        };
