    public static int[] ReplaceUsingLinq(IEnumerable<int> arrayFromExisting, IEnumerable<int> x)
        {
            var indices = x.ToArray();
            var i = 0;
            var newArray = arrayFromExisting.Select(val =>
            {
                if (val != -1) return val;
                var ret = indices[i];
                i++;
                return ret;
            }).ToArray();
            return newArray;
        }
        public static int[] ReplceUsingForLoop(int[] arrayExisting, IEnumerable<int> x)
        {
            
            var arrayReplacements = x.ToArray();
            var replaced = new int[arrayExisting.Length];
            var replacementIndex = 0;
            for (var i = 0; i < arrayExisting.Length; i++)
            {
                if (arrayExisting[i] < 0)
                {
                    replaced[i] = arrayReplacements[replacementIndex++];
                }
                else
                {
                    replaced[i] = arrayExisting[i];
                }
            }
            
            return replaced;
        }
        public static unsafe int[] ReplaceUsingPointers(int[] arrayExisting, IEnumerable<int> reps)
        {
           
            var arrayReplacements = reps.ToArray();
            int replacementsLength = arrayReplacements.Length;
            var replaced = new int[arrayExisting.Length];
            Array.Copy(arrayExisting, replaced, arrayExisting.Length);
            int existingLength = replaced.Length;
            fixed (int* existing = replaced, replacements = arrayReplacements)
            {
                int* exist = existing;
                int* replace = replacements;
                int i = 0;
                int x = 0;
                while (i < replacementsLength && x < existingLength)
                {
                    if (*exist == -1)
                    {
                        *exist = *replace;
                        i++;
                        replace++;
                    }
                    exist++;
                    x++;
                }
            }
            return replaced;
        }
        public static int[] ReplaceUsingLoopWithMissingArray(int[] arrayExisting, IEnumerable<int> x,
            int[] missingIndices)
        {
            
            var arrayReplacements = x.ToArray();
            var replaced = new int[arrayExisting.Length];
            Array.Copy(arrayExisting, replaced, arrayExisting.Length);
            var replacementIndex = 0;
            foreach (var index in missingIndices)
            {
                replaced[index] = arrayReplacements[replacementIndex];
                replacementIndex++;
            }
            return replaced;
        }
