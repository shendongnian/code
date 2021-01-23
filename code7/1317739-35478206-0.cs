    [Fact]
    public async void SO35470588_WrongValuePidValue()
    {
        // nuke, rebuild, and populate the table
        try { connection.Execute("drop table TPTable"); } catch { }
        connection.Execute(@"
    create table TPTable (Pid int not null primary key identity(1,1), Value int not null);
    insert TPTable (Value) values (2), (568)");
        // fetch the data using the query in the question, then force to a dictionary
        var rows = (await connection.QueryAsync<TPTable>("select * from TPTable"))
            .ToDictionary(x => x.Pid);
        // check the number of rows
        rows.Count.IsEqualTo(2);
        // check row 1
        var row = rows[1];
        row.Pid.IsEqualTo(1);
        row.Value.IsEqualTo(2);
        // check row 2
        row = rows[2];
        row.Pid.IsEqualTo(2);
        row.Value.IsEqualTo(568);
    }
    public class TPTable
    {
        public int Pid { get; set; }
        public int Value { get; set; }
    }
