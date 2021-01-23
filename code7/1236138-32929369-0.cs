	foreach (var item in outerDocuments.Join(innerdocuments,
	                                         outer => outer.DocumentId,
											 inner => inner.DocumentId,
											 (outer, inner) => new { OuterDoc = outer, InnerDoc = inner }))
	{
		item.InnerDoc.IsValid = item.OuterDoc.IsValid;
	}
