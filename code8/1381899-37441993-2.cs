    class NoPreviewCodeAction : CodeAction
    {
        private readonly Func<CancellationToken, Task<Solution>> createChangedSolution;
        public override string Title { get; }
        public override string EquivalenceKey { get; }
        public NoPreviewCodeAction(
            string title, Func<CancellationToken, Task<Solution>> createChangedSolution,
            string equivalenceKey = null)
        {
            this.createChangedSolution = createChangedSolution;
            Title = title;
            EquivalenceKey = equivalenceKey;
        }
        protected override Task<IEnumerable<CodeActionOperation>> ComputePreviewOperationsAsync(
            CancellationToken cancellationToken)
        {
            return Task.FromResult(Enumerable.Empty<CodeActionOperation>());
        }
        protected override Task<Solution> GetChangedSolutionAsync(
            CancellationToken cancellationToken)
        {
            return createChangedSolution(cancellationToken);
        }
    }
