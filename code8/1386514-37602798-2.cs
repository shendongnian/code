    public class ArchiveKeyClassifier : ITagger<ClassificationTag>
    {
        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;
        private Dictionary<string, ClassificationTag> _tags;
        
        public ArchiveKeyClassifier(ITextBuffer subjectBuffer, IClassificationTypeRegistryService classificationRegistry)
        {
            // Build the tags that correspond to each of the possible classifications
            _tags = new Dictionary<string, ClassificationTag> {
                { Classifications.ArchiveKey,    BuildTag(classificationRegistry, Classifications.ArchiveKey) },
                { Classifications.ArchiveKeyVar, BuildTag(classificationRegistry, Classifications.ArchiveKeyVar) }
            };
        }
        
        public IEnumerable<ITagSpan<ClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            if (spans.Count == 0)
                yield break;
            foreach (var span in spans) {
                if (span.IsEmpty)
                    continue;
                foreach (var identSpan in LexIdentifiers(span)) {
                    var ident = identSpan.GetText();
                    if (!ident.StartsWith("Archive") || !ident.EndsWith("Key"))
                        continue;
                    
                    var varSpan = new SnapshotSpan(
                        identSpan.Start + "Archive".Length,
                        identSpan.End - "Key".Length);
                    yield return new TagSpan<ClassificationTag>(new SnapshotSpan(identSpan.Start, varSpan.Start), _tags[Classifications.ArchiveKey]);
                    yield return new TagSpan<ClassificationTag>(varSpan, _tags[Classifications.ArchiveKeyVar]);
                    yield return new TagSpan<ClassificationTag>(new SnapshotSpan(varSpan.End, identSpan.End), _tags[Classifications.ArchiveKey]);
                }
            }
        }
        private static IEnumerable<SnapshotSpan> LexIdentifiers(SnapshotSpan span)
        {
            // Tokenize the string into identifiers and numbers, returning only the identifiers
            var s = span.GetText();
            for (int i = 0; i < s.Length; ) {
                if (char.IsLetter(s[i])) {
                    var start = i;
                    for (++i; i < s.Length && char.IsLetterOrDigit(s[i]); ++i);
                    yield return new SnapshotSpan(span.Start + start, i - start);
                    continue;
                }
                if (char.IsDigit(s[i])) {
                    for (++i; i < s.Length && char.IsLetterOrDigit(s[i]); ++i);
                    continue;
                }
                ++i;
            }
        }
        private static ClassificationTag BuildTag(IClassificationTypeRegistryService classificationRegistry, string typeName)
        {
            return new ClassificationTag(classificationRegistry.GetClassificationType(typeName));
        }
    }
