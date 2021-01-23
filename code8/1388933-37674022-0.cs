    public static class XNodeExtensions
    {
		public static void FlattenCollection(this XElement parent)
		{
			if (parent == null || parent.Parent == null)
				throw new ArgumentNullException();
			var children = parent.Elements();
			if (children.Count() == 0)
				return;
			XNamespace json = @"http://james.newtonking.com/projects/json";
			XName isArray = json + "Array";
			foreach (var child in children)
			{
				child.Remove();
				child.Name = parent.Name;
				child.Add(new XAttribute(isArray, true));
				parent.Parent.Add(child);
			}
			parent.Remove();
		}
    }
