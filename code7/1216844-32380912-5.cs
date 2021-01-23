    public class ViewModel
    {
        public List<Word> Words { get; private set; }
        public ViewModel()
        {
            var editableWords = new[] { "on", "of" };
            var text = "Do you know someone rich and famous? Is he confident, popular, and joyful all of the time—the epitome of mainstream success? Or, on the other hand, is he stressed, having second thoughts about his life choices, and unsure about the meaning of his life?";
            this.Words =
                text.Split(' ')
                    .Select(x => new Word
                    {
                        Value = x,
                        IsEditable = editableWords.Contains(x.ToLower())
                    })
                    .ToList();
        }
    }
