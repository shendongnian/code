    public List<Member> members = new List<Member>();
    public Form1()
    {
        InitializeComponent();
        Member me = new Member();
        me.ID = 3;
        me.Name = "Maarten";
        PersSkill skill1 = new PersSkill();
        skill1.Name = "Super Awsome Skill!";
        skill1.MoreInfo = "All the info you need";
        PersSkill skill2 = new PersSkill();
        skill1.Name = "name!";
        skill1.MoreInfo = "info";
        List<PersSkill> list = new List<PersSkill>();
        list.Add(skill1);
        list.Add(skill2);
        me.PersSkills = list;
    }
    public struct Member
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<TechSkill> PersSkills { get; set; }
        public List<TechSkill> TechSkills { get; set; }
    }
    public struct PersSkill
    {
        public string Name { get; set; }
        public string MoreInfo { get; set; }
    }
    public struct TechSkill
    {
        public string Name { get; set; }
        public string MoreInfo { get; set; }
    }
