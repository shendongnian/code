    using System;
    using System.Collections.Generic;
    using System.IO;
    namespace Extensions
    {
        /// <summary>Extension method to parse any character separated string OR file.</summary>
        /// <param name="mapFunction">Expression to map data to the desired format</param>
        /// <param name="separator">The character delimiting columns</param>
        /// <param name="skipLines">Amount of heading lines to skip</param>
        public static class TextReaderExtensions
        {
            public static IEnumerable<T> ParseCsvData<T>(this TextReader reader, Func<string[], T> mapFunction, char separator = ',', short skipLines = 1)
            {
                IEnumerable<string[]> readCsvLines()
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(line) && skipLines-- < 1)
                        {
                            yield return line.Split(separator);
                        }
                    }
                }
                foreach (var csvLine in readCsvLines())
                {
                    yield return mapFunction.Invoke(csvLine) ?? default;
                }
            }
        }
    }
