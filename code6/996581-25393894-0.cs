    var branchToRemove = _libraryService.GetLibrary(id);
    // .Single() will throw an exception unless there is one and only one match.
    var consortRemove = userConsortia.Single(
        c => c.Branches.Any(
            b => string.Equals(b.LibraryId, id, StringComparison.OrdinalIgnoreCase));
    // remove the consortia
    userConsortia.Remove(consortRemove);
