    using System.Linq;
    using System.Collections.Generic;
    public bool hasTriplet(int[] values)
    {
        foreach (int i in values)
        {
            if (values.Where(v => v == i).ToList().Count >= 3)
            {
                return true;
            }
        }
        return false;
    }
