    private DateTime InitialDate;
    private DateTime EndDate;
    
    
    this.dataInicial = new DateTime(radDateTimePickerInitialDate.Value.Year, radDateTimePickerInitialDate.Value.Month, radDateTimePickerInitialDate.Value.Day);
    this.dataFinal   = new DateTime(radDateTimePickerEndDate.Value.Year, radDateTimePickerEndDate.Value.Month, radDateTimePickerEndDate.Value.Day);
