    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        public sealed class BoyerMoore
        {
            public static IEnumerable<int> Search(byte[] haystack, byte[] needle)
            {
                if (needle.Length == 0)
                    yield break;
                var searcher = new BoyerMoore(haystack, needle);
                foreach (var index in searcher.search())
                    yield return index;
            }
            readonly byte[] haystack;
            readonly byte[] needle;
            readonly int[]  charTable;
            readonly int[]  offsetTable;
            BoyerMoore(byte[] haystack, byte[] needle)
            {
                this.haystack    = haystack;
                this.needle      = needle;
                this.charTable   = makeByteTable(needle);
                this.offsetTable = makeOffsetTable(needle);
            }
            IEnumerable<int> search()
            {
                for (int i = needle.Length - 1; i < haystack.Length;)
                {
                    int j;
                    for (j = needle.Length - 1; needle[j] == haystack[i]; --i, --j)
                    {
                        if (j != 0)
                            continue;
                        yield return i;
                        i += needle.Length - 1;
                        break;
                    }
                    i += Math.Max(offsetTable[needle.Length - 1 - j], charTable[haystack[i]]);
                }
            }
            static int[] makeByteTable(byte[] needle)
            {
                const int ALPHABET_SIZE = 256;
                int[] table = new int[ALPHABET_SIZE];
                for (int i = 0; i < table.Length; ++i)
                    table[i] = needle.Length;
                for (int i = 0; i < needle.Length - 1; ++i)
                    table[needle[i]] = needle.Length - 1 - i;
                return table;
            }
            static int[] makeOffsetTable(byte[] needle)
            {
                int[] table = new int[needle.Length];
                int lastPrefixPosition = needle.Length;
                for (int i = needle.Length - 1; i >= 0; --i)
                {
                    if (isPrefix(needle, i + 1))
                        lastPrefixPosition = i + 1;
                    table[needle.Length - 1 - i] = lastPrefixPosition - i + needle.Length - 1;
                }
                for (int i = 0; i < needle.Length - 1; ++i)
                {
                    int slen = suffixLength(needle, i);
                    table[slen] = needle.Length - 1 - i + slen;
                }
                return table;
            }
            static bool isPrefix(byte[] needle, int p)
            {
                for (int i = p, j = 0; i < needle.Length; ++i, ++j)
                    if (needle[i] != needle[j])
                        return false;
                return true;
            }
            static int suffixLength(byte[] needle, int p)
            {
                int len = 0;
                for (int i = p, j = needle.Length - 1; i >= 0 && needle[i] == needle[j]; --i, --j)
                    ++len;
                return len;
            }
        }
    }
