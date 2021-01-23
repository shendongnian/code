    public class Chromosome
    {
        public ChromosomeType CromosomeType { get; set; }
    }
    
    public enum ChromosomeType
    {
        R, B, D
    }
    
    public class ChromosomeList : List<Chromosome>
    {
        public ChromosomeList(IEnumerable<Chromosome> range) : base(range) { }
    
        public IEnumerable<Chromosome> FindBySequence(string patternRegex)
        {
            var stringRepresentation = this.ToString();
            var match = Regex.Match(stringRepresentation, patternRegex);
            //returns empty if no match is found
            return this.GetRange(stringRepresentation.IndexOf(match.Value), match.Value.Length);
        }
    
        public override string ToString()
        {
            return String.Join(
                    String.Empty, //no separator
                    (
                        from c in this
                        select c.CromosomeType.ToString()
                    )
                );
        }
    }
