        public class ClassWithList
        {
            public string Id { get; set; }
            public List<string> Items { get; set; }
            public List<ClassWithList> Nested { get; set; }
        }
        [TestClass]
        public class Test
        {
            [TestMethod]
            public void Should_compare_null_to_empty()
            {
                ClassWithList one = new ClassWithList { Id = "ten", Items = null, Nested = new List<ClassWithList> { new ClassWithList { Id = "a" } } };
                ClassWithList two = new ClassWithList { Id = "ten", Items = new List<string>(), Nested = new List<ClassWithList> { new ClassWithList { Id = "a", Items = new List<string>(), Nested = new List<ClassWithList> { } } } };
                two.ShouldBeEquivalentTo(one, opt => opt
                    .Using<IEnumerable>(CheckList)
                    .When(info => typeof(IEnumerable).IsAssignableFrom(info.CompileTimeType)));
            }
            private void CheckList(IAssertionContext<IEnumerable> a)
            {
                if (a.Expectation == null)
                {
                    a.Subject.Should().BeEmpty();
                }
                else
                {
                    a.Subject.ShouldBeEquivalentTo(a.Expectation, opt => opt
                        .Using<IEnumerable>(CheckList)
                        .When(info => typeof(IEnumerable).IsAssignableFrom(info.CompileTimeType)));
                }
            }
        }
