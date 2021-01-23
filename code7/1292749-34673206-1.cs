    List<MyViewModel> projects =
                   (from p in db.T_ProjectNumber
                   join u in db.unit on p.ProjectNumber equals u.ProjectNumber
                   where p.ProjectNumber.Contains(searchString)
                   select new MyViewModel()
                    {
                        MyViewModelProperty1 = p.ProjectNumber,
                        MyViewModelProperty2 = u.Stuff
                        // etc, etc
                    }).ToList();
