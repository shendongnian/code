        public void Customize(IFixture fixture)
        {
            fixture.Customize<Person>(composer =>
                composer.With(p => p.Name, "Ben"))
                                 .With(p => p.DateOfBirth, new DateTime(1900, 1, 1)));
        }
    }
