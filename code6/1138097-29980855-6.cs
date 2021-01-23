        public class ObsceneValue
    {
        public bool IsObscene
        {
            get { return Word != null; }
        }
        public string Word { get; set; }
        public char Character { get; set; }
        public ObsceneValue(char character, string fullWord = null)
        {
            Character = character;
            Word = fullWord;
        }
    }
