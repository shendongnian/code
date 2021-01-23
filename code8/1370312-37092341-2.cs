	// GET: Faculty/Create
	public ActionResult Create() {
		var facultyMemberViewModel = new FacultyMemberViewModel {
			DepartmentList = GetDepartmentList()
		};
		return View(facultyMemberViewModel);
	}
	// POST: Faculty/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Create([Bind(Include = "Id,Name,SelectedDepartments,DepartmentList")] FacultyMemberViewModel facultyMemberViewModel) {
		if (!ModelState.IsValid) {
            // Re-set the Department list.
			if (facultyMemberViewModel.DepartmentList == null) {
				facultyMemberViewModel.DepartmentList = GetDepartmentList();
			}
			return View(facultyMemberViewModel);
		}
		var facultyMember = new FacultyMember {
			Id = facultyMemberViewModel.Id,
			Name = facultyMemberViewModel.Name,
		};
		foreach (var departmentId in facultyMemberViewModel.SelectedDepartments) {
            // I'm assuming this is safe to do (aka the records exist in the database)...
			facultyMember.Departments.Add(db.Departments.Find(departmentId));
		}
		db.Faculty.Add(facultyMember);
		db.SaveChanges();
		return RedirectToAction("Index");
	}
