    public string RetrieveHolidayDatesFromSource() {
        var result = this.RetrieveHolidayDatesFromSourceAsync().Result;
        /** Do stuff **/
        var returnedResult  = this.TransformResults(result.Result); /** Where result gets used **/
        return returnedResult;
    }
