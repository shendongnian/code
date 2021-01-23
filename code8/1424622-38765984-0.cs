    // The following two methods are visible to users of your object
    public Employee GetEmployee(int id) {
        return GetEmployeeByIdOrName(id, null);
    }
    public Employee GetEmployee(string name) {
        return GetEmployeeByIdOrName(0, name);
    }
    // This private method provides an implementation
    private Employee GetEmployeeByIdOrName(int employeeid, string firstname) {
        ...
    }
