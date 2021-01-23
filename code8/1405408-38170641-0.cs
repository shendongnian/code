     ArrayList lx = new ArrayList();
            lx.Add("ABCD");
            lx.Add("ABDM");
            lx.Add("AMFD");
            lx.Add("MXKK");
            ArrayList mx = new ArrayList();
            foreach (string x in lx) {
                if (x.Contains('A')) {
                    mx.Add(x);
                }
            }
            foreach (string m in mx) {
                Console.WriteLine(m);
            }
            Console.ReadLine();
