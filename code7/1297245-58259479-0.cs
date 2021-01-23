	public class Human
	{
		public int Id { get; set; }
		public ICollection<Human> Children { get; set; }
		public Human Parent { get; set; }
		[ForeignKey("Parent")]
		public int ParentId { get; set; }
	}
	var family = await db.Humans
		.Where(h => h.SomeCriteriaForParent == criteria)
		.Select(h => new {
			H = h,
			HH = h.Children
		})
		.SelectMany(x => x.HH.Concat(new[] { x.H }))
		.ToArrayAsync();
