    return barUser.DepartmentPositions
             .Where(x => x.PositionType == PositionType.Manager)
             .Select(x => x.Department.Id)
             .Intersects(fooUser.DepartmentPositions.Select(x => X.Department.Id))
             .Any()
