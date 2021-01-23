	[Export(typeof(ITaggerProvider))]
	[ContentType("CSharp")]
	[TagType(typeof(ClassificationTag))]
	[Name("HighlightDisposableTagger")]
	public class HighlightDisposableTaggerProvider : ITaggerProvider
	{
		[Import]
		private IClassificationTypeRegistryService _classificationRegistry = null;
		[Import]
		private IClassifierAggregatorService _classifierAggregator = null;
		private bool _reentrant;
		public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
		{
			if (_reentrant)
				return null;
			try {
				_reentrant = true;
				var classifier = _classifierAggregator.GetClassifier(buffer);
				return new HighlightDisposableTagger(buffer, _classificationRegistry, classifier) as ITagger<T>;
			}
			finally {
				_reentrant = false;
			}
		}
	}
