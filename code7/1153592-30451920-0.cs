    Expression<Func<Student, ManagerStudentListViewModel>> GetSelectStatement()
    {
        var studentType = typeof(Student);
        var viewModelType = typeof(ManagerStudentListViewModel);
    
        var param = Expression.Parameter(studentType, "x");
        var nameValue = Expression.Property(param, "Name");
        var classTypeValue = Expression.Property(
                Expression.Property(param, "ClassType"), // get the class type
                "Description"); // get the description of the class type
        
        var nameMemberBinding = Expression.Bind(
                viewModelType.GetProperty("Name"),
                nameValue);
        var classTypeMemberBinding = Expression.Bind(
                viewModelType.GetProperty("ClassType"),
                classTypeValue);
        var initializer = Expression.MemberInit(
                Expression.New(viewModelType),
                nameMemberBinding,
                classTypeMemberBinding);
        return Expression.Lambda<Func<Student, ManagerStudentListViewModel>>(initializer, param);
    }
