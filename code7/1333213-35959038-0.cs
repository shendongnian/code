    public class Project
    {
        public string id { get; set; }
        public string client_id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string active { get; set; }
        public string billable { get; set; }
        public string bill_by { get; set; }
        public object hourly_rate { get; set; }
        public object budget { get; set; }
        public string budget_by { get; set; }
        public bool notify_when_over_budget { get; set; }
        public string over_budget_notification_percentage { get; set; }
        public object over_budget_notified_at { get; set; }
        public bool show_budget_to_all { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string starts_on { get; set; }
        public object ends_on { get; set; }
        public object estimate { get; set; }
        public string estimate_by { get; set; }
        public string hint_earliest_record_at { get; set; }
        public string hint_latest_record_at { get; set; }
        public string notes { get; set; }
        public string? cost_budget { get; set; }
        public bool cost_budget_include_expenses { get; set; }
    }
