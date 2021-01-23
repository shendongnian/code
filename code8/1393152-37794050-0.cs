    var inline = this.rtbEditor.CaretPosition.GetAdjacentElement(LogicalDirection.Forward) as Inline;
    if (inline != null)
    {
        this.AddAdorner(inline.NextInline as InlineUIContainer);
        this.AddAdorner(inline.PreviousInline as InlineUIContainer);
    }
