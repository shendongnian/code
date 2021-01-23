            String input = "[dog | cat | tiger | wolf][eats | bites | hunts][a bread | a meat | a fish]";
            String pattern = @"\[([^\[\]]+)\]";
            List<string[]> sentenceParts = new List<string[]>();
            foreach (Match m in Regex.Matches(input, pattern))
            {
                String mycontent = m.Groups[1].Value;
                String[] values = mycontent.Split('|');
                sentenceParts.Add(values);
            }
