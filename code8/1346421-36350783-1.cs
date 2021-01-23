    private static List<TreeNode> FillRecursive(List<Detail> flatObjects, int? parentId=null)
    {
      return flatObjects.Where(x => x.ParentID.Equals(parentId)).Select(item => new TreeNode
      {
        Name = item.Name, 
        Id = item.Id, 
        Children = FillRecursive(flatObjects, item.Id)
      }).ToList();
    }
