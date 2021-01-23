    class AccessPoint
    {
      public string Name  { get ; set ; }
      public int    Id    { get ; set ; }
      public bool   Value { get ; set ; }
    }
    
    static IEnumerable<AccessPoint> AccessPointsFromXml( XDocument doc )
    {
      AccessPoint item = null ;
      
      foreach( XElement e in doc.Root.Elements() )
      {
        switch ( e.Name.LocalName )
        {
        case "Name" :
          if ( item != null ) yield return item ;
          item = new AccessPoint{ Name = e.Value , } ;
          break ;
        case "Id" :
          int id ;
          int.TryParse(e.Value,out id) ;
          if ( item == null ) item = new AccessPoint() ;
          item.Id = id ;
          break ;
        case "Value" :
          bool value ;
          bool.TryParse(e.Value,out value) ;
          if ( item == null ) item = new AccessPoint() ;
          item.Value = value ;
          break ;
        }
      }
      
      // take care of the last item (if there is one)
      if ( item != null ) yield return item ;
    }
