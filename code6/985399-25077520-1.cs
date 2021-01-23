        /// <summary>
        /// Enumerate all the strings in a given flow document that are have an explicit background color.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="includeFlowDocumentColor">true to consider overrides on the entire FlowDocument itself, else false.</param>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<Brush, string>> WalkBackgroundColoredTexts(FlowDocument doc, bool includeFlowDocumentColor)
        {
            foreach (var pair in WalkTextElements<Brush>(doc, (d, s) => SelectTextBackgroundBrush(d, s, includeFlowDocumentColor)))
            {
                var brush = pair.Key.Peek();
                if (brush != null)
                {
                    yield return new KeyValuePair<Brush, string>(brush, pair.Value);
                }
            }
        }
        static Brush SelectTextBackgroundBrush(DependencyObject element, Stack<Brush> brushes, bool includeFlowDocumentColor)
        {
            //http://blogs.msdn.com/b/prajakta/archive/2006/10/11/flowdocument-content-model.aspx
            //http://msdn.microsoft.com/en-us/library/aa970786%28v=vs.110%29.aspx
            var textElement = element as TextElement;
            if (textElement != null)
            {
                var brush = textElement.Background;
                if (brush != null)
                    return brush;
                return PeekOrDefault(brushes);
            }
            var tableColumn = element as TableColumn;
            if (tableColumn != null)
            {
                var brush = tableColumn.Background;
                if (brush != null)
                    return brush;
                return PeekOrDefault(brushes);
            }
            if (includeFlowDocumentColor)
            {
                var doc = element as FlowDocument;
                if (doc != null)
                {
                    var brush = doc.Background;
                    if (brush != null)
                        return brush;
                    return PeekOrDefault(brushes);
                }
            }
            return null;
        }
        static T PeekOrDefault<T>(Stack<T> stack)
        {
            return (stack.Count == 0 ? default(T) : stack.Peek());
        }
