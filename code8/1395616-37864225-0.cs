    [Test]
            public void SortTill20AscRestDesc()
            {
                var src = new[] {4, 7, 9, 8, 20, 56, 78, 34, 2, 76, 84, 98};
                var expected = new[] {2, 4, 7, 8, 9, 20, 98, 84, 78, 76, 56, 34};
                var result = src
                    .Select(
                        i => new
                        {
                            IsAbove20 = i > 20,
                            Value = i
                        }
                    )
                    .OrderBy(e => e.IsAbove20)
                    .ThenBy(e => e.IsAbove20 ? int.MaxValue : e.Value)
                    .ThenByDescending(e => e.Value)
                    .Select(e=>e.Value);
                
                Assert.That(result.SequenceEqual(expected), Is.True);
            }
