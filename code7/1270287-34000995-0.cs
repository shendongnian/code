    static List<dynamic> DisplayTree(IEnumerable<NewMassType> elements) {
        var res = new List<dynamic>();
        foreach (var element in elements) {
            var children = DisplayTree(NewMassType.GetAll().Where(e => e.ParentId == element.Id)).ToArray();
            if (children.Length != 0) {
                res.Add(new {
                    name = element.Name
                ,   children = children
                })
            } else {
                res.Add(new {
                    name = element.Name
                })
            }
        }
        return res;
    }
