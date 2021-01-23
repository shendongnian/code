    abstract class Letter
    {
        public char Value { get; private set; }
        protected abstract void FrobInternal();
        public void Frob()
        {
            FrobInternal();
            // optionally code to be called for all letters
        }
        
        // private constructor limits inheritance to nested classes
        private Letter(char value) { Value = value; }
        class Vowel : Letter
        {
            public Vowel(char letter) : base(letter) { }
            sealed protected override void FrobInternal()
            {
                FrobVowel();
                AMethodIShouldCallOnAllVowels();
            }
            protected virtual void FrobVowel() { }
            private void AMethodIShouldCallOnAllVowels()
            {
                // Implementation...
            }
        }
        class Consonant : Letter
        {
            public Consonant(char letter) : base(letter) { }
            sealed protected override void FrobInternal()
            {
                FrobConsonant();
                AMethodIShouldCallOnAllConsanants();
            }
            protected virtual void FrobConsonant() { }
            private void AMethodIShouldCallOnAllConsanants()
            {
                // Implementation...
            }
        }
        class ConsonantBCD : Consonant
        {
            public ConsonantBCD(char letter) : base(letter) { }
            protected override void FrobConsonant()
            {
                // Special implemenation for B, C, D
            }
        }
        class LetterA : Vowel
        {
            public LetterA() : base('A') { }
            protected override void FrobVowel()
            {
                // Special implementation for A
            }
        }
        class LetterE : Vowel
        {
            public LetterE() : base('E') { }
            protected override void FrobVowel()
            {
                // Special implementation for E
            }
        }
        // use public readonly fields to replicate Enum functionality
        public static readonly Letter A = new LetterA();
        public static readonly Letter B = new ConsonantBCD('B');
        public static readonly Letter C = new ConsonantBCD('C');
        public static readonly Letter D = new ConsonantBCD('D');
        public static readonly Letter E = new LetterE();
        public static readonly Letter F = new Consonant('F');
        // ...   
        public static readonly Letter Z = new Consonant('Z');
    }
