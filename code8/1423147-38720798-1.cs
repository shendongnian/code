    var result = employeeCollection.Join(deptCollection,
            e => e.Id,
            dep => dep.EmployeeId,
            (e,dep) => new { E = e, DepetarmentName = dep.DepetarmentName })
        .Where(item => item.DepetarmentName == "a")
        .Select(item => item.E).ToList();
