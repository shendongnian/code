    List <MyObjectType> myIfListObjects = GetAllMyStuff();
    List <MyObjectType> myTrueListObjects = new List<MyObjectType>();
    List <MyObjectType> myElseListObjects = new List<MyObjectType>();
    myTrueListObjects =  myIfListObjects.Where( s => (s.SubSolicitud != null   
                                                 && s.SubSolicitud.Count() > 0)).ToList();
    myElseListObjects  = myIfListObjects.Where( s => (!(s.SubSolicitud != null   
                                                   && s.SubSolicitud.Count() > 0))).ToList();
    return;
