    List<B> listB;
    List<C> listC;
    // Concat version
    listB.Concat(listC).OrderBy(prop => prop.ID).ThenBy(prop => prop.AnotherID);
    
    // Intersect version
    listB.Intersect(listC).OrderBy(prop => prop.ID).ThenBy(prop => prop.AnotherID);
