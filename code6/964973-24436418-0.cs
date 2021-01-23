    [Test]
    public void then_a_valid_school_should_be_saved()
    {
        var _school = new School { .... };
        var expected = _school.Id;
        _repository.Setup(s => s.Insert(_school));
        _repository.Setup(s => s.GetById(_school.Id)).Returns(_school);;
        
        _repository.Insert(_school);
        var actual = _repository.GetById(_school.Id);
        Assert.Equal(expected, actual);
    }
