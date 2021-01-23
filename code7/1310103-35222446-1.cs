        string text = "";
        sampleDelegate s1 = () =>
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
        s1();
