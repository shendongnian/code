       private Dictionary<String, int> GetAllGroups(int GroupSize) {
            Dictionary<string, int> WordGroupInstances = new Dictionary<string, int>();
            StringBuilder groupBuilder = new StringBuilder();
            String[] sourceText = GetSourceText().Split(' ');
            for (int i = 0; i < sourceText.Length; i++) {
                groupBuilder.Clear();
                for (int j = 0; j < GroupSize; j++) {
                    if (i + j >= sourceText.Length) {
                        break;
                    }
                    groupBuilder.Append(" ").Append(sourceText[i + j]);
                    String groupString = groupBuilder.ToString().Substring(1);
                    if (!WordGroupInstances.ContainsKey(groupString)) {
                        WordGroupInstances.Add(groupString, 1);
                    } else {
                        WordGroupInstances[groupString]++;
                    }
                }
            }
            return WordGroupInstances;
        }
