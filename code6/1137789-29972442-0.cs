    public IEnumerable<BaseReadingDto> AllReadings {
      get{
        return MeterReadings.Concat(PseudoReadings);
      }
    }
