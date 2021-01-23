    public void DocDeletion.Delete(Doc doc)
    {
        var relatedEntities = relatedEntityRepository.FindRelatedEntitiesWithReportDate(doc.ReportDate);
        if (relatedEntities.Any())
        {
            DomainEvents.Raise(new RelatedEntityPreventedDocDeletionEvent(doc, relatedEntities));
        }
        else
        {
            // Assumes docRepository.Delete raises relevant domain event
            docRepository.Delete(doc);
        }
    }
