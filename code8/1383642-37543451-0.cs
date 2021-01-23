	var cmd = new OleDbCommand(@"
		SELECT  Customer.CID, Customer.FirstName, Customer.LastName, Booking.VehicleNumber, Customer.MemberType, Customer.Points, Booking.[Time], Booking.[Date]
		FROM    (Booking INNER JOIN
				Customer ON Booking.CID = Customer.CID)
		WHERE   Booking.[Date] = @booking_date");
	cmd.Parameters.Add("@booking_date", OleDbType.DBDate).Value = dateTimePicker2.Value;
	DataTable1TableAdapter.SelectCommand = cmd;
	//{...}
	this.DataTable1TableAdapter.Fill(this.DataReport.DataTable1);
	this.reportViewer1.RefreshReport();
