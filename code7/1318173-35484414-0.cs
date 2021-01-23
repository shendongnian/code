        public class EmployeeViewModel
        {
            // other employee properties you want to edit
            public int DepartmentId { get; set; }
        }
    Then, once you get to your post action, you'll need to map the values from this view model to your actual entity, and namely, use the posted value for `DepartmentId` to lookup the right department from the database in order to set the `Department` property on your employee.
