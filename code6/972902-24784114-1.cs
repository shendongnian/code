    public IEnumerable<ITagSpan<ClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
    {
      foreach (IClassifier classifier in (IEnumerable<IClassifier>) this.Classifiers)
      {
        foreach (SnapshotSpan span in spans)
        {
          foreach (ClassificationSpan classificationSpan in (IEnumerable<ClassificationSpan>) classifier.GetClassificationSpans(span))
            yield return (ITagSpan<ClassificationTag>) new TagSpan<ClassificationTag>(classificationSpan.Span, new ClassificationTag(classificationSpan.ClassificationType));
        }
      }
    }
