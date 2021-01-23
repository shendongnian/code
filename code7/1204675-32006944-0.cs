     var serviceMock = MockRepository.GenerateMock<IService>();
     var poco = new Poco { Data = "One" };
     serviceMock.Stub(x => x.DoSomething(
                    ref Arg<Poco>.Ref(Rhino.Mocks.Constraints.Is.Anything(), new Poco { Data = "One" }).Dummy, // I don't want to specify null here
                    ref Arg<int>.Ref(Rhino.Mocks.Constraints.Is.Equal(1), 2).Dummy));
     int returnValue = 1;
     serviceMock.DoSomething(ref poco, ref returnValue);
     Assert.AreEqual(2, returnValue); // pass
     Assert.AreEqual("One", poco.Data); // pass
