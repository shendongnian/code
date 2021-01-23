                    if (i % 10 == 0)
                    {
                        demo = new Demo(i);
                    }
                    #region code1
                    Thread t = new Thread(() =>
                    {
                        demo.SetName();
                        var names = demo.names;
