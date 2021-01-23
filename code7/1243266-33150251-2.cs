	public partial class Job
	{
		public int JOB_ID { get; set; }
		public string JOB_DESCRIPTION { get; set; }
		public byte[] TARGET_IMAGE { get; set; }
		public int JOB_USER { get; set; }
		public Job Clone()
		{
			return new Job {
				JOB_ID = this.JOB_ID,
				JOB_DESCRIPTION = this.JOB_DESCRIPTION,
				TARGET_IMAGE = this.TARGET_IMAGE,
				JOB_USER = this.JOB_USER
			};
		}
	}
