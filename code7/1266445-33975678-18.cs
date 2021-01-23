       private Dictionary<String, int> GetAllGroups() {
            Dictionary<string, int> WordGroupInstances = new Dictionary<string, int>();
            StringBuilder groupBuilder = new StringBuilder();
            String[] sourceText = GetSourceText().Split(' ');
            for (int i = 0; i < sourceText.Length; i++) {
                groupBuilder.Clear();
                for (int j = i; j < sourceText.Length; j++) {
                    groupBuilder.Append(" ").Append(sourceText[j]);
                    String key = groupBuilder.ToString().Substring(1);
                    if (!WordGroupInstances.ContainsKey(key)) {
                        WordGroupInstances.Add(key, 1);
                    } else {
                        WordGroupInstances[key]++;
                    }
                }
            }
            return WordGroupInstances;
        }
