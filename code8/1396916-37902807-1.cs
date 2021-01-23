    SqlCommand cmd5 = new SqlCommand(
        "select * from criminal where NIC = @nic", conn);
    var param = cmd5.Paramters.Add("nic", SqlDbType.SomethingRelevant);
    // ^^^ note: I don't know what the data type is, you'll need to pick that
    foreach(...) {
        param.Value = ((object)person.NIC) ?? DBNull.Value;
        using(var dr3 = cmd5.ExecuteReader()) {
          // ...
        }
    }
    ...
