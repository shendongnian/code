    // If you override Equals and GetHashCode or are comparing by reference
    DummyData.All(a=>CustomerName.Contains(a))
    
    //If you compare by property
    DummyData.All(a=>
                   CustomerName.Any(b=>
                       a.FirstName==b.FirstName && 
                       a.LastName == b.LastName
                       //repeat to include checks for all properties
                  )
              );
    
