    using System.Linq;
    using System.Collections.Generic;
    public bool hasTriplet(int[] values)
    {
        List<int> valueList = values.ToList();
        foreach (int i in valueList)
        {
            if (valueList.Where(v => v == i).ToList().Count >= 3)
            {
                return true;
            }
        }
        return false;
    }
