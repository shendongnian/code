        public partial class Nos_Templates
        {
            [Key]
            public Guid id { get; set; }
            public string template_name { get; set; }
            public string edit_region { get; set; }
            public string question_list { get; set; }
            public DateTime? create_date { get; set; }
            public Guid? creating_user { get; set; }
            public DateTime? update_date { get; set; }
            public Guid? updating_user { get; set; }
        }
