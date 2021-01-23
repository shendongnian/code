	public class PatientInfoBusiness
	{
		public IEnumerable<PatientInfo> GetPatientInfo()
		{
			IPatientInfoService proxy = new VRFactory().GetPatientInfoServiceProxy();
			var piData= proxy.GetPatientInfoSectionData();
			return piData.Select(a => new patientInfoVM
			{
			  AcknowledgedUserName = a.AcknowledgedUserName,
			  Description = a.Description,
			  PriorityCode = a.PriorityCode,
			  Status = a.Status
			});
		}
	}
