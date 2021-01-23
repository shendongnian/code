	using System;
	using System.Data;
	using ServiceStack;
	using ServiceStack.Data;
	using ServiceStack.OrmLite;
	namespace NestedTransactionTest
	{
		[Route("/test/ResolveViaIoC", Verbs = "GET")]
		public class Dto1 : IReturnVoid
		{
		}
		public class ResolveViaIoC : Service
		{
			readonly IDbConnectionFactory _factory;
			public ResolveViaIoC(IDbConnectionFactory factory)
			{
				_factory = factory;
			}
			public void Get(Dto1 request)
			{
				using (var conn = _factory.Open()) {
					using (var tran = conn.BeginTransaction()) {
						var kv = new KeyValue {
							Id = Guid.NewGuid().ToString(),
							TypeName = "ResolveViaIoC",
							Value = "empty",
							ExpireAfter = DateTime.Now
						};
						using (var nested = ResolveService<ResolveViaIoCNested>()) {
							nested.Get(new Dto1Nested());	
						}
						conn.Insert(kv);
						tran.Commit();
					}
				}
			}
		}
		[Route("/test/ResolveViaIoC/nested", Verbs = "GET")]
		public class Dto1Nested : IReturnVoid
		{
		}
		public class ResolveViaIoCNested : Service
		{
			readonly IDbConnectionFactory _factory;
			public ResolveViaIoCNested(IDbConnectionFactory factory)
			{
				_factory = factory;
			}
			public void Get(Dto1Nested request)
			{
				using (var conn = _factory.Open()) {
					using (var tran = conn.BeginTransaction()) {
						var kv = new KeyValue {
							Id = Guid.NewGuid().ToString(),
							TypeName = "ResolveViaIoCNested",
							Value = "empty",
							ExpireAfter = DateTime.Now
						};
							
						conn.Insert(kv);
						tran.Commit();
					}
				}
			}
		}
		public class KeyValue
		{
			public string Id { get; set; }
			public string TypeName { get; set; }
			public string Value { get; set; }
			public DateTime ExpireAfter { get; set; }
		}
	}
