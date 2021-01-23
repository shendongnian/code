	source
		.Subscribe(ia =>
		{
			var ia2 = ia.ToArray();
			var adds = ia2.Except(oc).ToArray();
			var removes = oc.Except(ia2).ToArray();
			foreach (var a in adds)
			{
				oc.Add(a);
			}
			foreach (var r in remove)
			{
				oc.Remove(r);
			}
		});
