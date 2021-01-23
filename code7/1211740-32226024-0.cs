    public List<int> GetAvailableMedicBiList()
    {
        using(var ctx = YourEntities())
        {
            return (List<int>)ctx.uSP_ListAvailableMedicBi().ToList();
        }
    }
