    public void SomeMethodThatAcceptsEmployee(Employee emp)
    {
    }
    Employee employee = new Employee();
    Manager manager = new Manager();
    // You can call this method passing Employee:
    SomeMethodThatAcceptsEmployee(employee);
    // But you can also call this method passing Manager:
    SomeMethodThatAcceptsEmployee(manager);
