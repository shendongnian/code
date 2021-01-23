			VerifyDuplicates duplicates = new VerifyDuplicates();
			List<MyClass> newClass = new List<MyClass>(); 
			classes = classes.OrderBy(s => s.Type).ToList();
			List<int> idsToDelete = new List<int>();
			for (int i = 0; i < classes.Count; i++)
			{
				if (i + 1 < classes.Count)
				{
					var x = duplicates.Compare(classes[i], classes[i + 1]);
					if (x == 1)
						idsToDelete.Add(classes[i+1].Id);
				}
			}
            newClass = classes.Where(n => !idsToDelete.Contains(n.Id)).Select(n => n).ToList();
		public class VerifyDuplicates : Comparer<MyClass>
		{
			public override int Compare(MyClass x, MyClass y)
			{
				int p = 0;
				if(x != null && y != null)
				{ 
					if(x.Type.Equals(y.Type)) { p += 1; }
					if(x.Attachments.Equals(y.Attachments)) { p += 1; }
					if(x.Capacity.Equals(y.Capacity)) { p += 1; }
					if(x.Goal.Equals(y.Goal)) { p += 1; }
					if(x.Hours.Equals(y.Hours)) { p += 1; }
					if(x.TypeDesignation.Equals(y.TypeDesignation)) { p += 1; }
					if(x.TypeControl != null && y.TypeControl != null)
						if(x.TypeControl[0].Equals(y.TypeControl[0])) { p += 1; }
					if(x.Supplies != null && y.Supplies!= null)
						if (x.Supplies.Equals(y.Supplies)) { p += 1; }
                    return p;
				}
          }
      }
