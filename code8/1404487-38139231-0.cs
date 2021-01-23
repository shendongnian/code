    // Requires these
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    public static void SortByAny(List<Person> listToSort, String sortBy)
    {
		listToSort.Sort((x, y) => TypeDescriptor.GetProperties(x.GetType()).Find(sortBy, true).DisplayName.CompareTo(TypeDescriptor.GetProperties(y.GetType()).Find(sortBy, true).DisplayName));
    }
