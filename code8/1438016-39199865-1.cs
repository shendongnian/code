    if (_Shifts != null)
    {
        ContexManager contex = new ContexManager();
        Shift _sht = _Shifts[0];         
        _sht.MyStartTime = dtStart1.Value.TimeOfDay;
        _sht.MyEndTime = dtEnd1.Value.TimeOfDay;
        _sht.MyName = txtShift1.Text;
        contex.Shifts.Attach(_sht);
        contex.Entry(_sht).State = EntityState.Modified;
        contex.SaveChanges();
    }
