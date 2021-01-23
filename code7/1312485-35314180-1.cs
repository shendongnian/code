    foreach (WorkItem workItem in workItemCollection)
    {
        Console.WriteLine("WI: {0}, Title: {1}", workItem.Id, workItem.Title);
        foreach (var changeset in
            workItem.Links
                .OfType<ExternalLink>()
                .Select(link => artifactProvider
                    .GetChangeset(new Uri(link.LinkedArtifactUri))))
        {
            Console.WriteLine(
                "CS: {0}, Comment: {1}",
                changeset.ChangesetId,
                changeset.Comment);
        }
    }
