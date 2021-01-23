            List<string> newStrings = new List<string>{
              "ABCD","ABDM","AMDF","XMKL"
            };
            List<string> lstA = newStrings.Where((s) => s[0] == 'A').ToList();
            foreach (string m in lstA) {
                Console.WriteLine(m);
            }
            Console.ReadLine();
