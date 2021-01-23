    public partial class Step
    {
        public IEnumerable<Step> TraverseSteps()
        {
            return RecursiveEnumerableExtensions.Traverse(this, s => s.StepList);
        }
    }
    public partial class Steps
    {
        public IEnumerable<Step> TraverseSteps()
        {
            return RecursiveEnumerableExtensions.Traverse(StepList, s => s.StepList);
        }
        public bool TryAdd(Step step, string parentId)
        {
            foreach (var item in TraverseSteps())
                if (item != null && item.Id == parentId)
                {
                    item.StepList.Add(step);
                    return true;
                }
            return false;
        }
        public void Add(Step step, string parentId)
        {
            if (!TryAdd(step, parentId))
                throw new InvalidOperationException(string.Format("Parent {0} not found", parentId));
        }
    }
