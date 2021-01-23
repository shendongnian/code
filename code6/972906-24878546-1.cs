	public class HighlightDisposableTagger : ITagger<ClassificationTag>
	{
		private const string DisposableFormatName = "HighlightDisposableFormat";
		[Export]
		[Name(DisposableFormatName)]
		public static ClassificationTypeDefinition DisposableFormatType = null;
		[Export(typeof(EditorFormatDefinition))]
		[Name(DisposableFormatName)]
		[ClassificationType(ClassificationTypeNames = DisposableFormatName)]
		[UserVisible(true)]
		public class DisposableFormatDefinition : ClassificationFormatDefinition
		{
			public DisposableFormatDefinition()
			{
				DisplayName = "Disposable Format";
				ForegroundColor = Color.FromRgb(0xFF, 0x00, 0x00);
			}
		}
		public event EventHandler<SnapshotSpanEventArgs> TagsChanged = delegate { };
		private ITextBuffer _subjectBuffer;
		private ClassificationTag _tag;
		private IClassifier _classifier;
		private bool _reentrant;
		public HighlightDisposableTagger(ITextBuffer subjectBuffer, IClassificationTypeRegistryService typeService, IClassifier classifier)
		{
			_subjectBuffer = subjectBuffer;
			var classificationType = typeService.GetClassificationType(DisposableFormatName);
			_tag = new ClassificationTag(classificationType);
			_classifier = classifier;
		}
		public IEnumerable<ITagSpan<ClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
		{
			if (_reentrant) {
				return Enumerable.Empty<ITagSpan<ClassificationTag>>();
			}
			var tags = new List<ITagSpan<ClassificationTag>>();
			try {
				_reentrant = true;
				foreach (var span in spans) {
					if (span.IsEmpty)
						continue;
					foreach (var token in _classifier.GetClassificationSpans(span)) {
						if (token.ClassificationType.IsOfType(/*PredefinedClassificationTypeNames.Identifier*/ "User Types")) {
							// TODO: Somehow figure out if this refers to a class which implements IDisposable
							if (token.Span.GetText() == "Stream") {
								tags.Add(new TagSpan<ClassificationTag>(token.Span, _tag));
							}
						}
					}
				}
				return tags;
			}
			finally {
				_reentrant = false;
			}
		}
	}
