    static IEnumerable<AccessPoint> AccessPointsFromXml( XmlDocument doc )
    {
      AccessPoint item = null ;
      foreach( XmlElement e in doc.DocumentElement.ChildNodes )
      {
        switch ( e.LocalName )
        {
        case "Name" :
          if ( item != null ) yield return item ;
          item = new AccessPoint{ Name = e.InnerText } ;
          break ;
        case "Id" :
          int id ;
          int.TryParse(e.InnerText,out id) ;
          if ( item == null ) item = new AccessPoint() ;
          item.Id = id ;
          break ;
        case "Value" :
          bool value ;
          bool.TryParse(e.InnerText,out value) ;
          if ( item == null ) item = new AccessPoint() ;
          item.Value = value ;
          break ;
        }
      }
      if ( item != null ) yield return item ;
    }
