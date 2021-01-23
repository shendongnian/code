    _dgCars.AutoGenerateColumns = false;
    
    DataGridViewTextBoxColumn makeColumn = new DataGridViewTextBoxColumn();
    makeColumn.DataPropertyName = "Make";
    makeColumn.HeaderText = "The Car's Make";
    
    DataGridViewTextBoxColumn modelColumn = new DataGridViewTextBoxColumn();
    modelColumn.DataPropertyName = "Model";
    modelColumn.HeaderText = "The Car's Model";
    
    DataGridViewTextBoxColumn yearColumn = new DataGridViewTextBoxColumn();
    yearColumn.DataPropertyName = "Year";
    yearColumn.HeaderText = "The Car's Year";
    
    _dgCars.Columns.Add(makeColumn);
    _dgCars.Columns.Add(modelColumn);
    _dgCars.Columns.Add(yearColumn);
    
    BindingList<Car> cars = new BindingList<Car>();
    
    cars.Add(new Car("Ford", "Mustang", 1967));
    cars.Add(new Car("Shelby AC", "Cobra", 1965));
    cars.Add(new Car("Chevrolet", "Corvette Sting Ray", 1965));
    
    _dgCars.DataSource = cars;
