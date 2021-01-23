    // using System.Collections.Generic;
    // using System.Linq;
    // create a list of your lists (however many there are):
    IEnumerable<IEnumerable<T>> lists = new IEnumerable<T>[] { list1, list2, list3, … };
    // find the first list that has more than 1 element:
    var list = lists.FirstOrDefault(list => list.Count() > 1);
    // if there is such a list…
    if (list != null)
    {
        // … then `DoSomething` to each of its items:
        foreach (T item in list)
        {
            DoSomething(item);
        }
    }
