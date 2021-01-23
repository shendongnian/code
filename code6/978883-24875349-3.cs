    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var r = RandomProvider.GetThreadRandom();
    
                Dictionary<int, int> resultDictionary = new Dictionary<int, int>();
                for (int x = 1; x <= 1000; x++)
                {
                    Dictionary<string, int> dictionary = new Dictionary<string, int>();
                    try
                    {
                        while (true)
                        {
                            int rand = r.Next(0, 1073741823);
                            CrockfordBase32Encoding encoding = new CrockfordBase32Encoding();
                            string encodedRand = encoding.Encode((ulong)rand, false);
                            dictionary.Add(encodedRand, rand);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    Console.WriteLine("{0} - {1}", x, dictionary.Count);
                    resultDictionary.Add(x, dictionary.Count);
                    x++;
                }
    
                Console.WriteLine();
                Console.WriteLine("Average Number Before Duplicate: " + resultDictionary.Average(x => x.Value));
                Console.WriteLine("Minimum Number Before Duplicate: " + resultDictionary.Min(x => x.Value));
                Console.WriteLine("Maximum Number Before Duplicate: " + resultDictionary.Max(x => x.Value));
                Console.WriteLine(" Median Number Before Duplicate: " + resultDictionary.Select(x=>x.Value).Median());
                Console.ReadLine();
            }
    
    
        }
    
        public static class Extensions
        {
            public static double Median<T>(this IEnumerable<T> list)
            {
                List<double> orderedList = list.Select(s=>Convert.ToDouble(s))
                    .OrderBy(numbers => numbers)
                    .ToList();
    
                int listSize = orderedList.Count;
                double result;
    
                if (listSize % 2 == 0) // even
                {
                    int midIndex = listSize / 2;
                    result = ((orderedList.ElementAt(midIndex - 1) +
                               orderedList.ElementAt(midIndex)) / 2);
                }
                else // odd
                {
                    double element = (double)listSize / 2;
                    element = Math.Round(element, MidpointRounding.AwayFromZero);
    
                    result = orderedList.ElementAt((int)(element - 1));
                }
    
                return result;
            } 
        }
    
    
        public static class RandomProvider
        {
            private static int seed = Environment.TickCount;
    
            private static ThreadLocal<Random> randomWrapper = new ThreadLocal<Random>(() =>
                new Random(Interlocked.Increment(ref seed))
                );
    
            public static Random GetThreadRandom()
            {
                return randomWrapper.Value;
            }
        }
    
        public class CrockfordBase32Encoding
        {
            const int Base = 32;
            const int CheckDigitBase = 37;
    
            static readonly IDictionary<int, char> valueEncodings;
            static readonly IDictionary<int, char> checkDigitEncodings;
            static readonly IDictionary<char, int> valueDecodings;
            static readonly IDictionary<char, int> checkDigitDecodings;
            static CrockfordBase32Encoding()
            {
                var symbols = new SymbolDefinitions();
                valueEncodings = symbols.ValueEncodings;
                checkDigitEncodings = symbols.CheckDigitEncodings;
                valueDecodings = symbols.ValueDecodings;
                checkDigitDecodings = symbols.CheckDigitDecodings;
            }
    
            public string Encode(ulong input, bool includeCheckDigit)
            {
                var chunks = SplitInto5BitChunks(input);
                var characters = chunks.Select(chunk => valueEncodings[chunk]);
    
                if (includeCheckDigit)
                {
                    var checkValue = (int)(input % CheckDigitBase);
                    characters = characters.Concat(new[] { checkDigitEncodings[checkValue] });
                }
    
                return new string(characters.ToArray());
            }
    
            internal static IEnumerable<byte> SplitInto5BitChunks(ulong input)
            {
                const int bitsPerChunk = 5;
                const int shift = (sizeof(ulong) * 8) - bitsPerChunk;
                var chunks = new List<byte>();
                do
                {
                    var lastChunk = input << shift >> shift;
                    chunks.Insert(0, (byte)lastChunk);
                    input = input >> bitsPerChunk;
                } while (input > 0);
                return chunks;
            }
    
            public ulong? Decode(string encodedString, bool treatLastCharacterAsCheckDigit)
            {
                if (encodedString == null)
                    throw new ArgumentNullException("encodedString");
    
                if (encodedString.Length == 0)
                    return null;
    
                IEnumerable<char> charactersInReverse = encodedString.Reverse().ToArray();
    
                int? expectedCheckValue = null;
                if (treatLastCharacterAsCheckDigit)
                {
                    var checkDigit = charactersInReverse.First();
                    if (!checkDigitDecodings.ContainsKey(checkDigit)) return null;
                    expectedCheckValue = checkDigitDecodings[checkDigit];
    
                    charactersInReverse = charactersInReverse.Skip(1);
                }
    
                ulong number = 0;
                ulong currentBase = 1;
                foreach (var character in charactersInReverse)
                {
                    if (!valueDecodings.ContainsKey(character)) return null;
    
                    var value = valueDecodings[character];
                    number += (ulong)value * currentBase;
    
                    currentBase *= Base;
                }
    
                if (expectedCheckValue.HasValue &&
                    (int)(number % CheckDigitBase) != expectedCheckValue)
                    return null;
    
                return number;
            }
        }
    
        internal class SymbolDefinitions : List<SymbolDefinition>
        {
            readonly List<SymbolDefinition> extraCheckDigits = new List<SymbolDefinition>();
    
            public SymbolDefinitions()
            {
                AddRange(new[]
                {
                    new SymbolDefinition { Value = 0, EncodeSymbol = '0', DecodeSymbols = new[] { '0', 'O', 'o' } },
                    new SymbolDefinition { Value = 1, EncodeSymbol = '1', DecodeSymbols = new[] { '1', 'I', 'i', 'L', 'l' } },
                    new SymbolDefinition { Value = 2, EncodeSymbol = '2', DecodeSymbols = new[] { '2' } },
                    new SymbolDefinition { Value = 3, EncodeSymbol = '3', DecodeSymbols = new[] { '3' } },
                    new SymbolDefinition { Value = 4, EncodeSymbol = '4', DecodeSymbols = new[] { '4' } },
                    new SymbolDefinition { Value = 5, EncodeSymbol = '5', DecodeSymbols = new[] { '5' } },
                    new SymbolDefinition { Value = 6, EncodeSymbol = '6', DecodeSymbols = new[] { '6' } },
                    new SymbolDefinition { Value = 7, EncodeSymbol = '7', DecodeSymbols = new[] { '7' } },
                    new SymbolDefinition { Value = 8, EncodeSymbol = '8', DecodeSymbols = new[] { '8' } },
                    new SymbolDefinition { Value = 9, EncodeSymbol = '9', DecodeSymbols = new[] { '9' } },
                    new SymbolDefinition { Value = 10, EncodeSymbol = 'A', DecodeSymbols = new[] { 'A', 'a' } },
                    new SymbolDefinition { Value = 11, EncodeSymbol = 'B', DecodeSymbols = new[] { 'B', 'b' } },
                    new SymbolDefinition { Value = 12, EncodeSymbol = 'C', DecodeSymbols = new[] { 'C', 'c' } },
                    new SymbolDefinition { Value = 13, EncodeSymbol = 'D', DecodeSymbols = new[] { 'D', 'd' } },
                    new SymbolDefinition { Value = 14, EncodeSymbol = 'E', DecodeSymbols = new[] { 'E', 'e' } },
                    new SymbolDefinition { Value = 15, EncodeSymbol = 'F', DecodeSymbols = new[] { 'F', 'f' } },
                    new SymbolDefinition { Value = 16, EncodeSymbol = 'G', DecodeSymbols = new[] { 'G', 'g' } },
                    new SymbolDefinition { Value = 17, EncodeSymbol = 'H', DecodeSymbols = new[] { 'H', 'h' } },
                    new SymbolDefinition { Value = 18, EncodeSymbol = 'J', DecodeSymbols = new[] { 'J', 'j' } },
                    new SymbolDefinition { Value = 19, EncodeSymbol = 'K', DecodeSymbols = new[] { 'K', 'k' } },
                    new SymbolDefinition { Value = 20, EncodeSymbol = 'M', DecodeSymbols = new[] { 'M', 'm' } },
                    new SymbolDefinition { Value = 21, EncodeSymbol = 'N', DecodeSymbols = new[] { 'N', 'n' } },
                    new SymbolDefinition { Value = 22, EncodeSymbol = 'P', DecodeSymbols = new[] { 'P', 'p' } },
                    new SymbolDefinition { Value = 23, EncodeSymbol = 'Q', DecodeSymbols = new[] { 'Q', 'q' } },
                    new SymbolDefinition { Value = 24, EncodeSymbol = 'R', DecodeSymbols = new[] { 'R', 'r' } },
                    new SymbolDefinition { Value = 25, EncodeSymbol = 'S', DecodeSymbols = new[] { 'S', 's' } },
                    new SymbolDefinition { Value = 26, EncodeSymbol = 'T', DecodeSymbols = new[] { 'T', 't' } },
                    new SymbolDefinition { Value = 27, EncodeSymbol = 'V', DecodeSymbols = new[] { 'V', 'v' } },
                    new SymbolDefinition { Value = 28, EncodeSymbol = 'W', DecodeSymbols = new[] { 'W', 'w' } },
                    new SymbolDefinition { Value = 29, EncodeSymbol = 'X', DecodeSymbols = new[] { 'X', 'x' } },
                    new SymbolDefinition { Value = 30, EncodeSymbol = 'Y', DecodeSymbols = new[] { 'Y', 'y' } },
                    new SymbolDefinition { Value = 31, EncodeSymbol = 'Z', DecodeSymbols = new[] { 'Z', 'z' } },
                });
    
                extraCheckDigits.AddRange(new[]
                {
                    new SymbolDefinition { Value = 32, EncodeSymbol = '*', DecodeSymbols = new[] { '*' } },
                    new SymbolDefinition { Value = 33, EncodeSymbol = '~', DecodeSymbols = new[] { '~' } },
                    new SymbolDefinition { Value = 34, EncodeSymbol = '$', DecodeSymbols = new[] { '$' } },
                    new SymbolDefinition { Value = 35, EncodeSymbol = '=', DecodeSymbols = new[] { '=' } },
                    new SymbolDefinition { Value = 36, EncodeSymbol = 'U', DecodeSymbols = new[] { 'U', 'u' } },
                });
            }
    
            public IDictionary<int, char> ValueEncodings
            {
                get
                {
                    return this.ToDictionary(s => s.Value, s => s.EncodeSymbol);
                }
            }
    
            public IDictionary<int, char> CheckDigitEncodings
            {
                get
                {
                    return this
                        .Union(extraCheckDigits)
                        .ToDictionary(s => s.Value, s => s.EncodeSymbol);
                }
            }
    
            public IDictionary<char, int> ValueDecodings
            {
                get
                {
                    return this
                        .SelectMany(s => s.DecodeSymbols.Select(d => new { s.Value, DecodeSymbol = d }))
                        .ToDictionary(s => s.DecodeSymbol, s => s.Value);
                }
            }
    
            public IDictionary<char, int> CheckDigitDecodings
            {
                get
                {
                    return this
                        .Union(extraCheckDigits)
                        .SelectMany(s => s.DecodeSymbols.Select(d => new { s.Value, DecodeSymbol = d }))
                        .ToDictionary(s => s.DecodeSymbol, s => s.Value);
                }
            }
        }
    
        internal class SymbolDefinition
        {
            public int Value { get; set; }
            public IEnumerable<char> DecodeSymbols { get; set; }
            public char EncodeSymbol { get; set; }
        }
    }
