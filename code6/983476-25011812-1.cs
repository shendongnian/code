    // using System.Collections.Generic;
    // using System.Linq;
    // create an enumerable "list" of your lists (however many there are):
    var lists = new[] { list1, list2, list3, … };
    // find the first list that has more than 1 element:
    var list = lists.FirstOrDefault(_ => _.Count() > 1);
    // if there is such a list…
    if (list != null)
    {
        // … then `DoSomething` to each of its items:
        foreach (var item in list)
        {
            DoSomething(item);
        }
    }
