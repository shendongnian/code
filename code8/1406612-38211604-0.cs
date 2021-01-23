    bool blDone = false;
    int iChckNo = 0;
    _status.TotalRecs = query.Count;
    Task.Run(() =>
    {
    	OrderablePartitioner<PayrollHeader> partitioner = Partitioner.Create(query, EnumerablePartitionerOptions.NoBuffering);
    	Parallel.ForEach(partitioner, thisCheck =>
    	{
    		lock (_status)
    		{
    			iChckNo++;
    			_status.ProcessMsg = "Voucher " + thisCheck.VoucherNumber;
    			_status.ProcessName = thisCheck.EmployeeName;
				_status.CurrentRec = iChckNo;
				dtSpan = DateTime.Now.Subtract(dtSpanStart);
				_status.TimeMsg = string.Format("Elapsed {0}:{1}:{2}", dtSpan.Hours, dtSpan.Minutes, dtSpan.Seconds);
			}
			thisCheck.GetDetails();
		});
	
		blDone = true;
	});
	
	while (!blDone)
	{
		WriteStatusUpdate();
	}
	
	further down in the code is
	
	private void WriteStatusUpdate()
	{
		lock (_status)
		{
			lblVoucher.Text = _status.ProcessMsg;
			lblName.Text = _status.ProcessName;
			lblCount.Text = string.Format("Records {0} of {1}", _status.CurrentRec, _status.TotalRecs);
			lblTime.Text = _status.TimeMsg;
			Application.DoEvents();
		}
	}
