    public class JobViewModel
    {
        public JobViewModel()
        {
            Machines = new List<Machine>();
        }
        public int Id { get; set; }
        public float Price { get; set; }
        public int JobSubCategoryId { get; set; }
        public string JobDescription { get; set; }
        public int SpecialRequirementId { get; set; }
        public List<Machine> Machines { get; set; }
        public string NewMachineBrand { get; set; }
        public string NewMachineType { get; set; }
        public string NewMachineName { get; set; }
        public void AddMachine()
        {
            Machine tmp = new Machine { Brand = NewMachineBrand, Type = NewMachineType, Name = NewMachineName };
            Machines.Add(tmp);
            NewMachineBrand = NewMachineType = NewMachineName = null;
        }
        public Job GetJob()
        {
            Job job = new Job();
            job.JobDescription = JobDescription;
            job.Price = Price;
            job.JobSubCategoryId = JobSubCategoryId;
            job.SpecialRequirementId = SpecialRequirementId;
            job.Machines = new List<Machine>();
            foreach (Machine m in Machines)
            {
                job.Machines.Add(m);
            }
            return job;
        }
    }
