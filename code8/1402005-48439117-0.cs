    public class Person
    {
    	public int Id;
    	public string FirstName;
    	public string LastName;
    }
    		
    [Test]
    public void Can_Map_Matching_Field_Names_Using_Dynamic()
    {
        // Arrange
        dynamic dynamicPerson = new ExpandoObject();
        dynamicPerson.Id = 1;
        dynamicPerson.FirstName = "Clark";
        dynamicPerson.LastName = "Kent";
    
        // Act
        var person = Slapper.AutoMapper.MapDynamic<Person>( dynamicPerson ) as Person;
                
        // Assert
        Assert.NotNull( person );
        Assert.That( person.Id == 1 );
        Assert.That( person.FirstName == "Clark" );
        Assert.That( person.LastName == "Kent" );
    }
