    public class Branch
    {
        public double Length { get; set; }
        public List<Branch> SubBranches { get; set; } = new List<Branch>();
    }
    public class Leaf : Branch
    {
        public string Name { get; set; }
    }
    public class Parser
    {
        private int currentPosition;
        private string input;
        public Parser(string text)
        {
            input = new string(text.Where(c=>!char.IsWhiteSpace(c)).ToArray());
            currentPosition = 0;
        }
        public Branch ParseTree()
        {
            return new Branch { SubBranches = ParseBranchSet() };
        }
        private List<Branch> ParseBranchSet()
        {
            var ret = new List<Branch>();
            ret.Add(ParseBranch());
            while (PeekCharacter() == ',')
            {
                currentPosition++; // ','
                ret.Add(ParseBranch());
            }
            return ret;
        }
        private Branch ParseBranch()
        {
            var tree = ParseSubTree();
            currentPosition++; // ':'
            tree.Length = ParseDouble();
            return tree;
        }
        private Branch ParseSubTree()
        {
            if (char.IsLetter(PeekCharacter()))
            {
                return new Leaf { Name = ParseIdentifier() };
            }
            currentPosition++; // '('
            var branches = ParseBranchSet();
            currentPosition++; // ')'
            return new Branch { SubBranches = branches };
        }        
        private string ParseIdentifier()
        {
            var identifer = "";
            char c;
            while ((c = PeekCharacter()) != 0 && (char.IsLetter(c) || c == '_'))
            {
                identifer += c;
                currentPosition++;
            }
            return identifer;
        }
        private double ParseDouble()
        {
            var num = "";
            char c;
            while((c = PeekCharacter()) != 0 && (char.IsDigit(c) || c == '.'))
            {
                num += c;
                currentPosition++;
            }
            return double.Parse(num, CultureInfo.InvariantCulture);
        }
        private char PeekCharacter()
        {
            if (currentPosition >= input.Length-1)
            {
                return (char)0;
            }
            return input[currentPosition + 1];
        }
    }
