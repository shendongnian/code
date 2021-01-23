    public IEnumerable<IAppointment> GetAppointmentsOnDate(DateTime date)
    {
        foreach (IAppointment item in _list)
        {
            if (item.Start == date)
            {
                yield return item;
            }
        }
    }
