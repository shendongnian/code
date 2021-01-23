    string text ="asasdfasdf";
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            Dictionary<string,int> letterCombos = new Dictionary<string,int>();
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    letterCombos.Add(alphabet[i] + alphabet[j].ToString(), 0);
                }
            }
            char[] textCharArray=text.ToCharArray();
            for (int i =0;i<text.Length-1;i++)
            {
                string partial = textCharArray[i] + textCharArray[i + 1].ToString();
                letterCombos[partial]++;
            }
            foreach (KeyValuePair<string, int> kp in letterCombos)
            {
                Console.WriteLine(kp.Key +": "+kp.Value);
            }
