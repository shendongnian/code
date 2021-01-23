    public partial class Job
        {
            public int JOB_ID { get; set; }
            public string JOB_DESCRIPTION { get; set; }
            public byte[] TARGET_IMAGE { get; set; }
            public int JOB_USER { get; set; }
            public Job Clone() {
            Job clone = new Job();
            clone.JOB_ID = this.JOB_ID;
            clone.JOB_DESCRIPTION = this.JOB_DESCRIPTION;
            clone.TARGET_IMAGE = this.TARGET_IMAGE;
            clone.JOB_USER = this.JOB_USER;
            return clone;
            }
        }
