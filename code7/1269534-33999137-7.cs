    [Test]
    public void ShouldCorrectlyMapA()
    {
        var objectA = new A
        {
            Id = 1,
            messageA = "Message A",
            Bs = new List<B> { 
                new B
                {
                    messageB = "Message B",
                    Cs = new List<C>
                    {
                        new C
                        {
                            messageC = "Message C"
                        }
                    }
                }
            }
        };
            
        new PersistenceSpecification<A>(_session)
            .VerifyTheMappings(objectA);
    }
