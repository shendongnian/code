	[Test]
	public void Foo() {
		var sample = new Record("abc");
		var sub = Substitute.For<IOrgTreeRepository<Record>>();
		sub.FirstOrDefault(Arg.Is<Func<Record,bool>>(f => f(sample))).Returns(sample);
		Assert.Null(sub.FirstOrDefault(x => x.Id == "def"));
		Assert.AreSame(sample, sub.FirstOrDefault(x => x.Id.StartsWith ("a")));
		Assert.AreSame(sample, sub.FirstOrDefault(x => x.Id == "abc"));
	}
