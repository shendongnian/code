    public static Test()
    {
      var ancestor= new Node();
      var parent = new Node(ancestor);
      var child = new Node(parent);
      var result = SearchInHierarchy(child, x => x.Name == "Foo");
    }
