    LinkData obj = new LinkData
    add stuff to the object 
    obj.type = db.Section.Where(s => s.ID==SectionID).Select s=> s.Type new s.Type).SingleOrDefault();
    obj.Route = db.Section.Where(s => s.ID==SectionID).Select s=> s.Route new s.Type).SingleOrDefault();;
    LinkDataList.Add(obj)
