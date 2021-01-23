    private class TestableObjectResult : ObjectResult<Animal>
        {
            public override IEnumerator<Animal> GetEnumerator()
            {
                return new List<Animal>() { new Animal(), new Animal() }.GetEnumerator();
            }
        }
