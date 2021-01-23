    [FactMySql]
    public void Issue426_SO34439033_DateTimeGainsTicks()
    {
        using (var conn = GetMySqlConnection())
        {
            try { conn.Execute("drop table Issue426_Test"); } catch { }
            try { conn.Execute("create table Issue426_Test (Id int not null, Time time not null)"); } catch { }
            const long ticks = 553440000000;
            const int Id = 426;
           
            var localObj = new Issue426_Test
            {
                Id = Id,
                Time = TimeSpan.FromTicks(ticks) // from code example
            };
            conn.Execute("replace into Issue426_Test values (@Id,@Time)", localObj);
            
            var dbObj = conn.Query<Issue426_Test>("select * from Issue426_Test where Id = @id", new { id = Id }).Single();
            dbObj.Id.IsEqualTo(Id);
            dbObj.Time.Value.Ticks.IsEqualTo(ticks);
            
        }
    }
