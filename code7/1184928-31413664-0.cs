    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void FewerCurlies()
        {
            List<Action> actions = new List<Action>();
            for (int i = 0; i < 100; i++)
            {
                int x;
                if (i % 3 == 0)
                {
                    actions.Add(() => x = 10);
                }
    
                int y;
                if (i % 3 == 1)
                {
                    actions.Add(() => y = 10);
                }
            }
        }
    
        static void MoreCurlies()
        {
            List<Action> actions = new List<Action>();
            for (int i = 0; i < 100; i++)
            {
                {
                    int x;
                    if (i % 3 == 0)
                    {
                        actions.Add(() => x = 10);
                    }
                }
    
                {
                    int y;
                    if (i % 3 == 1)
                    {
                        actions.Add(() => y = 10);
                    }
                }
            }
        }
    }
