            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //Used the following two formulas so that it doesn't round down on the returned integer
            decimal totalPages = ((decimal)(viewModel.Teachers.Count() /(decimal) pageSize));     
            ViewBag.TotalPages = Math.Ceiling(totalPages);  
            //These next two functions could maybe be reduced to one function....would require some testing and building
            viewModel.Teachers = viewModel.Teachers.ToPagedList(pageNumber, pageSize);
            ViewBag.OnePageofTeachers = viewModel.Teachers;
            ViewBag.PageNumber = pageNumber;
            return View(viewModel);
