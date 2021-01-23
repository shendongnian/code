        private Dictionary<String, int> GetWordGroupInstances(int GroupSize) {
            Dictionary<String, int> WordGroupInstances = new Dictionary<string, int>();
            //Grab the string to work from...
            String[] sourceText = GetSourceText().Split(' ');
            int pointer = 0;
            StringBuilder groupBuilder = new StringBuilder();
            while (pointer < sourceText.Length - GroupSize) {
                groupBuilder.Clear();
                int offset = pointer + GroupSize;
                for (int i = pointer; i < offset; i++) {
                    //prepend a space to allow separation between words in groups. 
                    //We can make a substring from this later starting from char 1 
                    //to lose the initial whitespace from the string.
                    groupBuilder.Append(" ").Append(sourceText[i]);
                }
                String key = groupBuilder.ToString().Substring(1);
                if (!WordGroupInstances.ContainsKey(key)) {
                    WordGroupInstances.Add(key, 1);
                } else {
                    WordGroupInstances[key]++;
                }
                /**
                 * Setting the pointer to increase by group size grabs a group, moves on
                 * to the end of the group, and grabs the next.
                 * 
                 */
                pointer += GroupSize;
                /**
                 * Setting the point to increment by 1 grabs a group, advances by 1 word, then
                 * grabs the next, so from the phrase - "Hello world, I'm some text", the groups of size 2 would be
                 * "Hello world,", "world, I'm", "I'm some" etc...
                 */
                //pointer++;
            }
            return WordGroupInstances;
        }
