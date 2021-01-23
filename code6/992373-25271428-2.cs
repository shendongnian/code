    // this writes only the (concatenated) text nodes
    Console.WriteLine(xe.First().Value);
    // this writes the inner XML, including elements
    var reader = xe.First().CreateReader();
    reader.MoveToContent();
    Console.WriteLine(reader.ReadInnerXml());
