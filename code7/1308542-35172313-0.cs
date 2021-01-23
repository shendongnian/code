    [Route("api/sensors/{id}/{date}/Measurements")]
    public IEnumerable<Measurement> GetMeasurements(int id, DateTime date)//date == "11:01:2016 00:00:00"
    {
        return _unitOfWork.MeasurementRepository.Get(orderBy: e =>
            e.Where(ex => ex.SensorId == id).Where
            (a => EntityFunctions.TruncateTime(a.Time) == date.ToShortDateString())
            .OrderBy(tx => tx.Time));
    }
