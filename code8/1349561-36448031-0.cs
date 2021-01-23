    public class MyViewModel
    {
        public MyViewModel()
        {
            SizeChoices = new List<int>();
        }
        public int ChosenSize { get; set; }
        public IEnumerable<int> SizeChoices { get; set; }
        public SelectList SizeChoicesSelectList
        {
            get
            {
                return new SelectList(SizeChoices);
            }
        }
    }
