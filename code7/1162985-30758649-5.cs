		public class AMap: ClassMap<A>
		{
			public AMap()
			{
				Table("dbo.A");
				Id(x => x.ID).Not.Nullable();
				HasMany(u => u.Bs).KeyColumn("ID").Cascade.SaveUpdate();
			}
		}
		public class BMap: ClassMap<B>
		{
			public BMap()
			{
				Table("dbo.B");
				Map(x => x.ID, "ID").Not.Nullable();
                References(x => x.A, "ID").Not.Nullable();
			}
		}
		
