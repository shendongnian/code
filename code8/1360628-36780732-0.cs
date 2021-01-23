    private void LoadViewBag() 
    {
            //create query to find all committees
            var query = from m in db.Majors
                        orderby m.Major
                        select m;
            //execute query and store in list
            List<Majors> allMajors = query.ToList();
            //convert list to select list format needed for HTML
            SelectList allMajorsList = new SelectList(allMajors, "MajorID", "Major");
            ViewBag.AllMajors = allMajorsList;
            //create query to find all committees
            var query2 = from c in db.Companies
                        orderby c.CompanyName
                        select c;
            //execute query and store in list
            List<Company> allCompanies = query2.ToList();
            //convert list to select list format needed for HTML
            SelectList allCompaniesList = new SelectList(allCompanies, "CompanyID", "CompanyName");
            ViewBag.AllCompanies = allCompaniesList;
            //create query to find all committees
            var query3 = from i in db.Industries
                         orderby i.IndustryName
                         select i;
            //execute query and store in list
            List<Industry> allIndustries = query3.ToList();
            //convert list to select list format needed for HTML
            SelectList allIndustriesList = new SelectList(allIndustries, "IndustryID", "IndustryName");
            ViewBag.AllIndustries = allIndustriesList;
    }
