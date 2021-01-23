	public class EncryptionReport {
		//Other properties
		
		public string Acc_date_formatted { get { return Acc_date.ToString("YYYY-mm-dd H:mm:ss");} ]
	}
    List<EncryptionReport> result = null;
	result = m_encryptionSvc.GetReportsFromRefnr(tuples);
	result = result
	  .OrderByDecending(e => e.Acc_date)
	  .ToList();
    
