    public static string ReadRsdToJson(List<AttributeProperties> attrList)
    {
      var root = new TreeNode();
      foreach (var attr in attrList)
      {
         var pathElements = attr.XPath.Split('/');
         var current = root;
         // Scan down the path following or building the tree at each step
         foreach (var pathElement in pathElements)
         {
            if (current.ContainsKey(pathElement))
              current = current[pathElement];
            else
            {
               var newChild = new TreeNode(pathElement);
               current.AddChild(newChild);
               current = newChild;
            }
         }
         // current is now the node at leaf of the tree that you want
         current.Value = attr.Value;
      }
      // And now you have built a tree you can serialize that to Json
      // If you must write your own serializer instead of using JSON.NET
      // consider using string.Join(",",...) instead of trimming commas
    }
