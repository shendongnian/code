    // step 1: verify your string taken from excel
    var cellString = dataBlock.ValueCell.Value.ToString();
    // if you have a blank space there, remove it
    cellString = cellString.Replace(' ', '');
    // step 2: verify your double converted value
    var doubleValue = double.Parse(cellString);
    Console.WriteLine("doubleValue = " + doubleValue);
    
    // step 3: verify the formatting
    var formattedValue = doubleValue.ToString("#.##0");
    Console.WriteLine("formattedValue = " + formattedValue);
    dataBlock.ValueCell.Value = formattedValue;
