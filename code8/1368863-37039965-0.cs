    public class Book
    {
        // The set of books we recognize
        private static readonly List<Book> books;
        private static readonly Dictionary<string, Book> commonMisspellings;
        static Book()
        {
            // Initialize the set
            books = new List<Book>{
                // Old Testament
                new Book("Genesis", "Gen.", "Ge", 50), // Gen
                new Book("Exodus", "Ex.", "Ex", 40),  // Exod
                new Book("Leviticus", "Lev.", "Le", 27), // Lev
                new Book("Numbers", "Num.", "Nu", 36), // Num
                new Book("Deuteronomy", "Deut.", "De", 34), // Deut
                new Book("Joshua", "Josh.", "Jos", 24), // Josh
                new Book("Judges", "Judg.", "Jud", 21), // Judg
                new Book("Ruth", "Ruth", "Ru", 4), // Ruth
                new Book("1 Samuel", "1 Sam.", "1 S", 31), // 1Sam
                new Book("2 Samuel", "2 Sam.", "2 S", 24), // 2Sam
                new Book("1 Kings", "1 Kings", "1 K", 22), // 1Kgs
                new Book("2 Kings", "2 Kings", "2 K", 25), // 2Kgs
                new Book("1 Chronicles", "1 Chron.", "1 Chr", 29), // 1Chr
                new Book("2 Chronicles", "2 Chron.", "2 Chr", 36), // 2Chr
                new Book("Ezra", "Ezra", "Ezr", 10), // Ezra
                new Book("Nehemiah", "Neh.", "Ne", 13), // Neh
                new Book("Esther", "Est.", "Est", 10), // Esth
                new Book("Job", "Job", "Jb", 42), // Job
                new Book("Psalms", "Ps.", "Ps", 150), // Ps
                new Book("Proverbs", "Prov.", "Pr", 31), // Prov
                new Book("Ecclesiastes", "Eccl.", "Ec", 12), // Eccl
                new Book("Song of Solomon", "Song", "Song", 8), // Song
                new Book("Isaiah", "Isa.", "Is", 66), // Isa
                new Book("Jeremiah", "Jer.", "Je", 52), // Jer
                new Book("Lamentations", "Lam.", "Lam", 5), // Lam
                new Book("Ezekiel", "Ezek.", "Ez", 48), // Ezek
                new Book("Daniel", "Dan.", "Da", 12), // Dan
                new Book("Hosea", "Hos.", "Ho", 14), // Hos
                new Book("Joel", "Joel", "Joel", 3), // Joel
                new Book("Amos", "Amos", "Am", 9), // Amos
                new Book("Obadaiah", "Obad.", "Obad", 1), // Obad
                new Book("Jonah", "Jonah", "Jona", 4), // Jonah
                new Book("Micah", "Mic.", "Mi", 7), // Mic
                new Book("Nahum", "Nah.", "Na", 3), // Nah
                new Book("Habakkuk", "Hab.", "Hab", 3), // Hab
                new Book("Zephaniah", "Zeph.", "Zep", 3), // Zeph
                new Book("Haggai", "Hag.", "Hag", 2), // Hag
                new Book("Zechariah", "Zech.", "Zec", 14), // Zech
                new Book("Malachai", "Mal.", "Mal", 4), // Mal
                // New Testament
                new Book("Matthew", "Matt.", "Mt", 28), // Matt
                new Book("Mark", "Mark", "Mk", 16), // Mark
                new Book("Luke", "Luke", "Lu", 24), // Luke
                new Book("John", "John", "Jn", 21), // John
                new Book("Acts", "Acts", "Ac", 28), // Acts
                new Book("Romans", "Rom.", "Ro", 16), // Rom
                new Book("1 Corinthians", "1 Cor.", "1 Co", 16), // 1Cor
                new Book("2 Corinthians", "2 Cor.", "2 Co", 13), // 2Cor
                new Book("Galatians", "Gal.", "Ga", 6), // Gal
                new Book("Ephesians", "Eph.", "Ep", 6), // Eph
                new Book("Philippians", "Phil.", "Ph", 4), // Phil
                new Book("Colossians", "Col.", "Col", 4), // Col
                new Book("1 Thessalonians", "1 Thes.", "1 Th", 5), // 1Thess
                new Book("2 Thessalonians", "2 Thes.", "2 Th", 3), // 2Thess
                new Book("1 Timothy", "1 Tim.", "1 Ti", 6), // 1Tim
                new Book("2 Timothy", "2 Tim.", "2 Ti", 4), // 2Tim
                new Book("Titus", "Titus", "Tit", 3), // Titus
                new Book("Philemon", "Philem.", "Phm", 1), // Phlm
                new Book("Hebrews", "Heb.", "He", 13), // Heb
                new Book("James", "James", "Ja", 5), // Jas
                new Book("1 Peter", "1 Peter", "1 Pe", 5), // 1Pet
                new Book("2 Peter", "2 Peter", "2 Pe", 3), // 2Pet
                new Book("1 John", "1 John", "1 Jn", 5), // 1John
                new Book("2 John", "2 John", "2 Jn", 1), // 2John
                new Book("3 John", "3 John", "3 Jn", 1), // 3John
                new Book("Jude", "Jude", "Jude", 1), // Jude
                new Book("Revelation", "Rev.", "Re", 22) // Rev
            };
            Debug.Assert(books.Count == 66);
            // These are based on what I found in the set of over 6,000
            // transcripts that people typed.
            commonMisspellings = new Dictionary<string, Book>();
            commonMisspellings.Add("song of songs", books.FirstOrDefault(b => b.ThompsonAbreviation == "Song"));
            commonMisspellings.Add("psalm", books.FirstOrDefault(b => b.ThompsonAbreviation == "Ps"));
            commonMisspellings.Add("like", books.FirstOrDefault(b => b.ThompsonAbreviation == "Lu"));
            commonMisspellings.Add("jerimiah", books.FirstOrDefault(b => b.ThompsonAbreviation == "Je"));
            commonMisspellings.Add("galations", books.FirstOrDefault(b => b.ThompsonAbreviation == "Ga"));
        }
        private static int numCreated = 0;
        private int order;
        private Book(string fullName, string abbrev, string thompsan, int chapters)
        {
            order = numCreated;
            Name = fullName;
            StandardAbreviation = abbrev;
            ThompsonAbreviation = thompsan;
            ChapterCount = chapters;
            numCreated++;
        }
        /// <summary>
        /// The unabbreviated name of the book.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Standard abbreviations as defined in "The Christian Writer's
        /// Manual of Style", 2004 edition (ISBN: 9780310487715).
        /// </summary>
        public string StandardAbreviation { get; private set; }
        /// <summary>
        /// Thompson Chain references, pulled from the 5th edition.
        /// </summary>
        public string ThompsonAbreviation { get; private set; }
        /// <summary>
        /// The number of chapters in the book.
        /// </summary>
        public int ChapterCount { get; private set; }
        public static bool TryParse(string inString, out Book book)
        {
            string potentialBook = StandardizeBookOrdinals(inString);
            // Find the first book where the input string now matches one of the recognized formats.
            book = books.FirstOrDefault(
                b => b.ThompsonAbreviation.Equals(potentialBook, StringComparison.InvariantCultureIgnoreCase) 
                    || b.StandardAbreviation.Equals(potentialBook, StringComparison.InvariantCultureIgnoreCase)
                    || b.Name.Equals(potentialBook, StringComparison.InvariantCultureIgnoreCase));
            if (book != null)
            {
                return true;
            }
            // If we didn't find it, check to see if we just missed it because the abbreviation
            // didn't have a period
            book = books.FirstOrDefault((b) =>
            {
                string stdAbrev = b.StandardAbreviation;
                if(stdAbrev.EndsWith("."))
                {
                    stdAbrev = stdAbrev.Substring(0, stdAbrev.Length - 1);
                }
                return potentialBook == stdAbrev;
            });
            if (book != null)
            {
                return true;
            }
            // Special Case: check for common misspellings
            string lowercase = potentialBook.ToLowerInvariant();
            commonMisspellings.TryGetValue(lowercase, out book);
            return book != null;
        }
        private static string StandardizeBookOrdinals(string str)
        {
            // Break up on all remaining white space
            string[] parts = (str ?? "").Trim().Split(' ', '\r', '\n', '\t');
            // If the first part is a roman numeral, or spelled ordinal, convert it to arabic
            var number = parts[0].ToLowerInvariant();
            switch (number)
            {
                case "first":
                case "i":
                    parts[0] = "1";
                    break;
                case "second":
                case "ii":
                    parts[0] = "2";
                    break;
                case "third":
                case "iii":
                    parts[0] = "3";
                    break;
            }
            // Recompile the parts into one string that only has a single space separating elements
            return string.Join(" ", parts);
        }
        public static IEnumerable<Book> List()
        {
            return books.ToArray();
        }
    }
