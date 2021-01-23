            string[] linesA = new string[5] { "41 Boundary Rd", "93 Boswell Terrace", "4/100 Lockrose St", "32 Williams Ave", "27 scribbly gum st sunnybank hills"};
            foreach (string line in linesA)
            {
                string[] words = line.Split(' ');
                Console.WriteLine(string.Join(" ",words.Skip(3)));
            }
