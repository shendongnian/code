    public async Task<IEnumerable<appointments>> GetApptTask(){
            var result = db.appointments.Where(d => d.appt_client_id == 15 && d.customer_id == 68009);
            return await result.ToListAsync();//result was an IQueryable here
        }
    public async Task <IEnumerable<zones>> GetZoneTask()
        {
            var result = db.zones.Where(d => d.zone_client_id == "15").AsEnumerable().Distinct<zones>(new zones.Comparer());
            return await result.ToListAsync();//here result is an IEnumberable because of the above call to AsEnumberable
        }
