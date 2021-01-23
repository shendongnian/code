    Publisher = pub == null ? default(Publisher) : new Publisher()
    {
        PublisherID = pub.Field<int>("PublisherID"),
        GroupID = pub.Field<int>("GroupID"),
        FirstName = pub.Field<string>("FirstName"),
        LastName = pub.Field<string>("LastName"),
        MiddleName = pub.Field<string>("MiddleName"),
        Gender = (Gender)pub.Field<int>("Gender"),
        Nationality = pub.Field<string>("Nationality"),
    },
