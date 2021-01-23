    [HttpGet]
    public JsonResult GetChildren(string key, bool isRoot)
    {
        // Populates the tree using AJAX and lazy loading nodes.
        // Lazy loading makes it possible to load nodes on the fly.
        // jstree will perform AJAX requests as the user browses the tree.
        //  
        // children = true, this special value indicated to jstree, that it has to lazy load the child node node.
        // https://github.com/vakata/jstree#populating-the-tree-using-ajax
        if (isRoot)
        {
            var first = new[]
            {
                new
                {
                    id = "root-id",
                    text = "Selected object in the list",
                    state = new
                    {
                        opened = true,
                    },
                    children = new[]
                    {
                        new
                        {
                            id = "child-1",
                            text = "Child 1",
                            children = true
                        },
                        new
                        {
                            id = "child-2",
                            text = "Child 2",
                            children = true
                        }
                    }
                }
            }
            .ToList(); 
            return new JsonResult { Data = first, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        var g1 = Guid.NewGuid().ToString();
        var g2 = Guid.NewGuid().ToString();
        var next = new[]
        {
            new
            {
                id = "child-" + g1,
                text = "Child " + g1,
                children = true
            },
            new {
                id = "child-" + g2,
                text = "Child " + g2,
                children = true
            }
        }
        .ToList();
        return new JsonResult { Data = next, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
    }
