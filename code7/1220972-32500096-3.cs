    var rootNode = new RootObject();
    rootNode.name = null;
    rootNode.parent = null;
    rootNode.children = new List<RootParent>();
    using (var connection = new SqlConnection(Common.ConnectionString))
    using (var command = new SqlCommand("SELECT ...", connection)) {
        connection.Open();
        using (var reader = command.ExecuteReader()) {
            rootNode.name = (string) reader["COLUMN A"];
            while (reader.Read()) {
                var parentNode = new RootParent();
                parentNode.name = (string) reader["COLUMN B"];
                parentNode.children = new ParentChild[] {
                    new ParentChild {
                        name = (string) reader["COLUMN C"],
                        parent = (string) reader["COLUMN B"],
                        children = null
                    };
                };
                rootNode.children.Add(parentNode);
            }
        }
    }
