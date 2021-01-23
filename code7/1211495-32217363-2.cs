        public unsafe string MyConcat(List<string> values)
        {
            int index = 0;
            int totalLength = values.Sum(m => m.Length);
            char* concat = stackalloc char[totalLength + 1]; // Add additional char for null term
            foreach (var value in values)
            {
                foreach (var c in value)
                {
                    concat[index] = c;
                    index++;
                }
            }
            concat[index] = '\0';
            return new string(concat);
        }
