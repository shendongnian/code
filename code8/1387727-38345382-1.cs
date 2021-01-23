    // GET: Student
    public ViewResult Index(string sortOrder, string currentFilter, string searchString, string currentFilter2, string searchString2,string currentFilter3, string searchString3, int? page)
    {
      ViewBag.CurrentSort = sortOrder;
      ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
      ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
      if (searchString != null)
      {
        page = 1;
      }
      else
      {
        searchString = currentFilter;
      }
    ViewBag.CurrentFilter = searchString;
    
    if (searchString2 != null)
      {
        page = 1;
      }
      else
      {
        searchString2 = currentFilter2;
      }
    ViewBag.CurrentFilter2 = searchString2;
    
       if (searchString3 != null)
      {
        page = 1;
      }
      else
      {
        searchString3 = currentFilter3;
      }
    ViewBag.CurrentFilter3 = searchString3;
    var students = from s in db.Students orderby s.LastName
                   select s;
    if (!String.IsNullOrEmpty(searchString))
    {
        //students = students.Where(s => s.LastName.Contains(searchString)
        //                       || s.FirstMidName.Contains(searchString));
    }
    switch (sortOrder)
    {
        case "name_desc":
            students = students.OrderByDescending(s => s.LastName);
            break;
        case "Date":
            students = students.OrderBy(s => s.EnrollmentDate);
            break;
        case "date_desc":
            students = students.OrderByDescending(s => s.EnrollmentDate);
            break;
        default:  // Name ascending 
            students = students.OrderBy(s => s.LastName);
            break;
    }
     int pageSize = 3;
     int pageNumber = (page ?? 1);
     return View(students.ToPagedList(pageNumber, pageSize));
    }
