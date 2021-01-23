    public static class XmlTagMapBuilder
    {
        public static IDictionary<string, IList<int>> GetOpenTagIndexMap(string inputXml)
        {
            // Argument validation goes here
    
            IDictionary<string, IList<int>> result = new Dictionary<string, IList<int>>();
    
            int currentIndex = -1;
            string lastOpenTag = null;
            while (true)
            {
                string nextOpenTagName;
                int nextOpenTagIndex;
                if (TryGetNextOpenTagIndex(inputXml, currentIndex, out nextOpenTagName, out nextOpenTagIndex))
                {
                    lastOpenTag = nextOpenTagName;
                    currentIndex = nextOpenTagIndex;
    
                    IList<int> tagIndicies;
                    if (!result.TryGetValue(nextOpenTagName.ToUpperInvariant(), out tagIndicies))
                    {
                        tagIndicies = new List<int>();
                        result.Add(nextOpenTagName, tagIndicies);
                    }
    
                    tagIndicies.Add(nextOpenTagIndex);
                }
                else
                {
                    break;
                }
            }
    
            return result;
        }
    
        /// <summary>
        /// Tries to get next open tag in the given <see cref="inputXml"/> string after the specified startIndex.
        /// </summary>
        /// <param name="inputXml">The string which contains the xml tags.</param>
        /// <param name="startIndex">The index after which to look for the open tag.</param>
        /// <param name="nextOpenTagName">If a tag was found, contains its name.</param>
        /// <param name="nextOpenTagIndex">If a tag was found, contains the start index of it.</param>
        /// <returns>true - if the tag was found. false - otherwise.</returns>
        private static bool TryGetNextOpenTagIndex(string inputXml, int startIndex, out string nextOpenTagName, out int nextOpenTagIndex)
        {
            // Need to add implementaiton here
        }
    }
