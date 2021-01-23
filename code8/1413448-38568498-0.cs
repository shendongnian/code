    using NodaTime;
    using System.Collections.Generic;
    using System.Linq;
    namespace Domain.Extensions
    {
        public static class IsoDayOfWeekExtensions
        {
            public static IReadOnlyList<IReadOnlyList<IsoDayOfWeek>> GroupConsecutive(this IList<IsoDayOfWeek> days)
            {
                var groups = new List<List<IsoDayOfWeek>>();
                var group = new List<IsoDayOfWeek>();
                var daysList = days.Distinct().OrderBy(x => (int)x);
                foreach (var day in daysList)
                {
                    if (!group.Any() || (int)day - (int)group.Last() == 1)
                    {
                        group.Add(day);
                    }
                    else
                    {
                        groups.Add(group);
                        group = new List<IsoDayOfWeek>() { day };
                    }
                }
                // Last group will not have been added yet. Check if the last group can be combined with the first group (Sunday and Monday are also consecutive!)
                if (group.Contains(IsoDayOfWeek.Sunday) && groups.Any() && groups.First().Contains(IsoDayOfWeek.Monday))
                {
                    // Insert before the Monday so that the days are in the correct consecutive order.
                    groups.First().InsertRange(0, group);
                }
                else
                {
                    groups.Add(group);
                }
                return groups.Select(x => x.ToList()).ToList();
            }
        }
    }
