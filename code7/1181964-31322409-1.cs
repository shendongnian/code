    /// <summary>
    /// Find the best possible merge base given two or more <see cref="Commit"/> according
    /// to the <see cref="MergeBaseFindingStrategy"/>.
    /// </summary>
    /// <param name="commits">
    /// The <see cref="Commit"/>s for which to find the merge base.
    /// </param>
    /// <param name="strategy">
    /// The strategy to leverage in order to find the merge base.
    /// </param>
    /// <returns>The merge base or null if none found.</returns>
    public virtual Commit FindMergeBase(IEnumerable<Commit> commits,
         MergeBaseFindingStrategy strategy)
