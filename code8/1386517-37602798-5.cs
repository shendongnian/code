    [Export(typeof(ITaggerProvider))]
    [ContentType("text")]    // or whatever content type your tagger applies to
    [TagType(typeof(ClassificationTag))]
    public class ArchiveKeyClassifierProvider : ITaggerProvider
    {
        [Import]
        public IClassificationTypeRegistryService ClassificationTypeRegistry { get; set; }
        public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
        {
            return buffer.Properties.GetOrCreateSingletonProperty(() =>
                new ArchiveKeyClassifier(buffer, ClassificationTypeRegistry)) as ITagger<T>;
        }
    }
