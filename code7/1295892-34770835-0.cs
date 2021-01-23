    using System;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var word = new Word("turtle");
    
                // either of these methods should be run at least once otherwise .HasWon will be true
                // hint: do that in constructor as you wish
                //word.RemoveAllOccurrencesOf('t');
                word.RemoveSomeChars();
    
                word.TryPlaceChar('u');
                word.TryPlaceChar('l');
                word.TryPlaceChar('e');
            }
        }
    
        internal class Word
        {
            private const char Separator = '_';
            private readonly char[] _chars;
            private readonly string _name;
    
            public char[] Chars
            {
                get { return _chars; }
            }
    
            public string CharsAsString
            {
                get { return new string(_chars); }
            }
    
            public string Name
            {
                get { return _name; }
            }
    
            public bool HasWon
            {
                get
                {
                    return CharsAsString == Name;
                }
            }
    
            public Word(string name)
            {
                _name = name;
                _chars = _name.ToCharArray();
            }
    
            public void RemoveAllOccurrencesOf(char c)
            {
                for (int i = 0; i < _chars.Length; i++)
                {
                    var c1 = _chars[i];
                    if (c1 == c) _chars[i] = Separator;
                }
            }
    
            public void RemoveSomeChars(int percentage = 50)
            {
                var length = this._name.Length;
                var random = new Random();
                int count = (int)(length * (percentage / 100.0d));
                for (int i = 0; i < count; i++)
                {
                    var next = random.Next(length);
                    this._chars[next] = Separator;
                }
            }
    
            public void TryPlaceChar(char c)
            {
    
                for (int i = 0; i < _chars.Length; i++)
                {
                    if (_chars[i] == Separator && _name[i] == c)
                    {
                        _chars[i] = c;
                    }
                }
            }
        }
    }
