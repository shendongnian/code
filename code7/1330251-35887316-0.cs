    [Test]
    public void TestPersonUpdateSendsEventWithCorrectPayload()
    {
        // ARRANGE
        PersonUpdatedEventArgs payload = null;
        _eventAggregator
            .GetEvent<PersonUpdatedEvent>()
            .Subscribe(message => payload = message);
        // ACT
        _personService.UpdatePerson(5);
        // ASSERT
        payload.Should().NotBeNull();
        payload.Id.Should().Be(5);
    }
