    class RegexReplacer
    {
        public string Pattern { get; private set; }
        public string Replacement { get; private set; }
        public string GroupName { get; private set; }
        public RegexReplacer NextReplacer { get; private set; }
        public RegexReplacer(string pattern, string replacement, string groupName, RegexReplacer nextReplacer = null)
        {
            this.Pattern = pattern;
            this.Replacement = replacement;
            this.GroupName = groupName;
            this.NextReplacer = nextReplacer;
        }
        public string GetAggregatedPattern()
        {
            string constructedPattern = this.Pattern;
            string alternation = (this.NextReplacer == null ? string.Empty : "|" + this.NextReplacer.GetAggregatedPattern());   // If there isn't another replacer, then we won't have an alternation; otherwise, we build an alternation between this pattern and the next replacer's "full" pattern
            constructedPattern = string.Format("(?<{0}>{1}){2}", this.GroupName, this.Pattern, alternation);    // The (?<XXX>) syntax builds a named capture group. This is used by our GetReplacementDelegate metho.
            return constructedPattern;
        }
        public MatchEvaluator GetReplaceDelegate()
        {
            return (match) =>
            {
                if (match.Groups[this.GroupName] != null && match.Groups[this.GroupName].Length > 0)    // Did we get a hit on the group name?
                {
                    return this.Replacement;
                }
                else if (this.NextReplacer != null)                                                     // No? Then is there another replacer to inspect?
                {
                    MatchEvaluator next = this.NextReplacer.GetReplaceDelegate();
                    return next(match);
                }
                else
                {
                    return match.Value;                                                                 // No? Then simply return the value
                }
            };
        }
    }
