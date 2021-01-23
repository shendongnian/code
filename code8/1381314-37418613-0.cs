    // explicitly convert NSDate to DateTime to change format
    DateTime date = (DateTime)ContactDatePicker.Date;
	DateTime time = (DateTime)ContactTimePicker.Date;
    // able to overload ToString() method with argument to change format
	var selectedDate = date.ToString ("d");
	var selectedTime = time.ToString ("HH:mm:ss");
