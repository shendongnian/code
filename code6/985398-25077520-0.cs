        public static IEnumerable<KeyValuePair<Stack<T>, string>> WalkTextElements<T>(FlowDocument doc, Func<DependencyObject, Stack<T>, T> selector)
        {
            // Inspiration: http://www.bryanewert.net/journal/2010/5/26/how-to-explore-the-contents-of-a-flowdocument.html
            if (doc != null)
            {
                var stack = new Stack<T>();
                // Start with a TextPointer to FlowDocument.ContentStart
                TextPointer t = doc.ContentStart;
                // Keep a TextPointer for FlowDocument.ContentEnd handy, so we know when we're done.
                TextPointer e = doc.ContentEnd;
                // Keep going until the TextPointer is equal to or greater than ContentEnd.
                while ((t != null) && (t.CompareTo(e) < 0))
                {
                    // Identify the type of content immediately adjacent to the text pointer.
                    TextPointerContext context = t.GetPointerContext(LogicalDirection.Forward);
                    // ElementStart is an "opening tag" which defines the structure of the document, e.g. a paragraph declaration.
                    if (context == TextPointerContext.ElementStart)
                    {
                        stack.Push(selector(t.Parent, stack));
                    }
                    // An EmbeddedElement, e.g. a UIContainer.
                    else if (context == TextPointerContext.EmbeddedElement)
                    {
                        ; // Do nothing.
                    }
                    // The document's text content.
                    else if (context == TextPointerContext.Text)
                    {
                        stack.Push(selector(t.Parent, stack));
                        yield return new KeyValuePair<Stack<T>, string>(stack, t.GetTextInRun(LogicalDirection.Forward));
                        stack.Pop();
                    }
                    // ElementEnd is a "closing tag".
                    else if (context == TextPointerContext.ElementEnd)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        throw new System.Exception("Unhandled TextPointerContext " + context.ToString());
                    }
                    // Advance to the next ContentElement in the FlowDocument.
                    t = t.GetNextContextPosition(LogicalDirection.Forward);
                }
            }
        }
