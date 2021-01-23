    return barUser.DepartmentPositions
             .Where(x => x.PositionType == PositionType.Manager)
             .Select(x => x.Department.Id)
             .Intersect(fooUser.DepartmentPositions.Select(x => X.Department.Id))
             .Any()
