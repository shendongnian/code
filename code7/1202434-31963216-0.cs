    [TestMethod]
            public async Task TestMethod2()
            {
                var c = new Mock<ICourseRepository>();
                Course a = new Course { CourseId = 1 };
                c.Setup(x => x.Add(a)).Verifiable();
                c.Object.Add(a);
                c.VerifyAll();
            }
