    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void FewerCurlies()
        {
            List<Action> actions = new List<Action>();
            for (int i = 0; i < 100; i++)
            {
                FewerCurliesCapture capture = new FewerCurliesCapture();
                if (i % 3 == 0)
                {
                    actions.Add(capture.Method1);
                }
    
                if (i % 3 == 1)
                {
                    actions.Add(capture.Method2);
                }
            }
        }
    
        static void MoreCurlies()
        {
            List<Action> actions = new List<Action>();
            for (int i = 0; i < 100; i++)
            {
                {
                    MoreCurliesCapture1 capture = new MoreCurliesCapture1();
                    if (i % 3 == 0)
                    {
                        actions.Add(capture.Method);
                    }
                }
    
                {
                    MoreCurliesCapture1 capture = new MoreCurliesCapture2();
                    if (i % 3 == 1)
                    {
                        actions.Add(capture.Method);
                    }
                }
            }
        }
        private class FewerCurliesCapture
        {
            public int x;
            public int y;
            public void Method1()
            {
                x = 10;
            }
            public void Method2()
            {
                y = 10;
            }
        }
        private class MoreCurliesCapture1
        {
            public int x;
            public void Method()
            {
                x = 10;
            }
        }
        private class MoreCurliesCapture2
        {
            public int y;
            public void Method()
            {
                y = 10;
            }
        }
    }
