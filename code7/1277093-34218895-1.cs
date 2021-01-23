    void RemoveRecursively(List<Item> list, int id)
    {
        list.RemoveAll(x => x.ID == id);
        
        foreach (var item in list.Where(x => x.ParentID == id)) 
            RemoveRecursively(list, item.ID);
    }
    
