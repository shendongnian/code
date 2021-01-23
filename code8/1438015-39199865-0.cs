    if (_Shifts != null)
    {
        ContexManager contex = new ContexManager();
        Foreach(var shiftitem in _Shifts)
        {
            shiftitem.MyStartTime = dtStart1.Value.TimeOfDay;
            shiftitem.MyEndTime = dtEnd1.Value.TimeOfDay;
            shiftitem.MyName = txtShift1.Text;
            contex.Shifts.Attach(shiftitem);
            contex.Entry(shiftitem).State = EntityState.Modified;
        }
        contex.SaveChanges();
    }
