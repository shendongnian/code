    public static class ChromosomesExtensions
    {
        public static IEnumerable<Chromosome> FindBySequence(this IEnumerable<Chromosome> chromosomes, string patternRegex)
        {
            var sequenceString
                = String.Join(
                    String.Empty, //no separator
                    (
                        from c in chromosomes
                        select c.CromosomeType.ToString()
                    )
                );
            var match = Regex.Match(sequenceString, patternRegex);
            //returns empty if no match is found
            return chromosomes.ToList().GetRange(sequenceString.IndexOf(match.Value), match.Value.Length);
        }
    }
