        /// <summary>
        /// Out of a set of CodeType instances, some of them may be different partials of the same class.
        /// This method filters down such a set so that you get only one partial per class.
        /// </summary>
        private static List<CodeType> PickArbitraryRepresentativeOfPartialClasses(IEnumerable<CodeType> codeTypes)
        {
            var representatives = new List<CodeType>();
            foreach (var codeType in codeTypes) {
                var codeClass2 = codeType as CodeClass2;
                if (codeClass2 != null) {
                    var matchesExistingRepresentative = (from candidate in representatives.OfType<CodeClass2>()
                                                         let candidatePartials = candidate.PartialClasses.OfType<CodeClass2>()
                                                         where candidatePartials.Contains(codeClass2)
                                                         select candidate).Any();
                    if (!matchesExistingRepresentative)
                        representatives.Add(codeType);
                } else {
                    // Can't have partials because it's not a CodeClass2, so it can't clash with others
                    representatives.Add(codeType);
                }
            }
            return representatives;
        }
    }
