    Data = reader;
    // You cant do this. You have to loop the reader to get the values from it.
    // If you simply assign reader object itself as the data you wont be 
    // able to get data once the reader or connection is closed. 
    // The reader is typically closed in the method.
    Data = reader.Cast<dynamic>;
    // You should call the Cast method. And preferably execute the resulting query. 
    // As of now you're merely assigning method reference to a variable
    // which is not what you want. 
    // Also bear in mind that, as I said before there's no real benefit in casting to dynamic
    Data = reader.Cast<IEnumerable<dynamic>>;
    // Cast method itself returns an IEnumerable. 
    // You dont have to cast individual rows to IEnumerable
    Data = reader.Cast<IEnumerable<string>>;
    // Meaningless I believe. 
    // The data you get from database is not always strings
