    return source
        .GroupBy(vm => new { vm.AccountName, vm.Ref1, vm.Ref2})
        .SelectMany(group =>
            {
                if (string.IsNullOrWhiteSpace(group.Key.Ref1) ||
                    string.IsNullOrWhiteSpace(group.Key.Ref2))
                {
                    // keep the group separate
                    return (IEnumerable<AccountViewModel>)group;
                }
                else
                {
                    // just use one item
                    return new[] { group.First() };
                }
            });
