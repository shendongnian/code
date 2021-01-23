    class Letter
    {
        public bool ischosen { get; set; }
        public char value { get; set; }
    }
    
    class LetterList
    {
        public LetterList(string word)
        {
            _lst = new List<Letter>();
            word.ToList().ForEach(x => _lst.Add(new Letter() { value = x }));
        }
    
        public bool FindLetter(char letter)
        {
            var search = _lst.Where(x => x.value == letter).ToList();
            search.ForEach(x=>x.ischosen=true);
            return search.Count > 0 ? true : false;
        }
    
        public string NotChosen()
        {
            var res = "";
            _lst.Where(x => !x.ischosen).ToList().ForEach(x => { res += x.value; });
            return res;
        }
    
        List<Letter> _lst;
    
    
    }
