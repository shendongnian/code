    class Program
    {
        static void Main(string[] args)
        {
            var str = @"{
              ""total_entries"": 598042,
              ""page"": 1,
              ""_links"": {
                ""self"": {
                  ""href"": ""\/api\/v2\/cases?page=1&per_page=50"",
                  ""class"": ""page""
                },
                ""first"": {
                  ""href"": ""\/api\/v2\/cases?page=1&per_page=50"",
                  ""class"": ""page""
                },
                ""last"": {
                  ""href"": ""\/api\/v2\/cases?page=11961&per_page=50"",
                  ""class"": ""page""
                },
                ""previous"": null,
                ""next"": {
                  ""href"": ""\/api\/v2\/cases?page=2&per_page=50"",
                  ""class"": ""page""
                }
              },
              ""_embedded"": {
                ""entries"": [
                  {
                    ""id"": 1,
                    ""external_id"": null,
                    ""blurb"": ""I want to personally thank you for signing up to try Desk.com! To ensure you get the most out of your trial,
                     here are some helpful tips and quick ways to get started: \\n\\n1. USE IT - You\\u2019ve got 14 days to try us out - please do so and tell us what you t"",
                    ""priority"": 4,
                    ""locked_until"": null,
                    ""label_ids"": [
                      
                    ],
                    ""active_at"": ""2015-01-21T15: 10: 48Z"",
                    ""changed_at"": ""2015-01-21T15: 15: 44Z"",
                    ""created_at"": ""2015-01-20T16: 24: 09Z"",
                    ""updated_at"": ""2015-01-21T15: 15: 44Z"",
                    ""first_opened_at"": ""2015-01-21T15: 10: 47Z"",
                    ""opened_at"": ""2015-01-21T15: 10: 47Z"",
                    ""first_resolved_at"": ""2015-01-21T15: 15: 44Z"",
                    ""resolved_at"": ""2015-01-21T15: 15: 44Z"",
                    ""status"": ""resolved"",
                    ""active_notes_count"": 0,
                    ""active_attachments_count"": 0,
                    ""has_pending_interactions"": false,
                    ""has_failed_interactions"": false,
                    ""description"": null,
                    ""language"": null,
                    ""received_at"": ""2015-01-20T16: 24: 09Z"",
                    ""type"": ""email"",
                    ""labels"": [
                      
                    ],
                    ""subject"": ""Getting Started with Your New Account"",
                    ""route_status"": ""available"",
                    ""custom_fields"": {
                      ""exclude_portal"": null,
                      ""exclude_notifications"": null,
                      ""case_type"": null,
                      ""product"": null,
                      ""severity"": null,
                      ""knowledge_status"": null,
                      ""desk_case_id"": null,
                      ""sla_status"": null,
                      ""priority"": null,
                      ""sla_violation"": null,
                      ""sla_milestone_completed"": null,
                      ""sync_to_salesforce"": null,
                      ""7616_pa2"": null,
                      ""7643_pa1"": null,
                      ""7714_pa1"": null,
                      ""7616_pa1"": null,
                      ""7643_pa2"": null,
                      ""7714_pa2"": null,
                      ""entitlement_name"": null,
                      ""escalation_level"": null,
                      ""testing"": null,
                      ""defect_number"": null,
                      ""channel"": null,
                      ""product_version"": null,
                      ""exclude_from_reporting"": null,
                      ""cw_id"": null,
                      ""desk_agent_id"": null,
                      ""desk_agent_name"": null,
                      ""solution_codes"": null,
                      ""7723_pa2"": null,
                      ""7670_pa2"": null,
                      ""7661_pa1"": null,
                      ""7634_pa2"": null,
                      ""7670_pa1"": null,
                      ""7758_pa1"": null,
                      ""7634_pa1"": null,
                      ""7688_pa1"": null,
                      ""7723_pa1"": null,
                      ""7688_pa2"": null,
                      ""7661_pa2"": null,
                      ""7758_pa2"": null,
                      ""7697_pa1"": null,
                      ""problem_area_1"": null,
                      ""problem_area_2"": null,
                      ""spam"": null,
                      ""salesforce_problem_area_1"": null,
                      ""salesforce_problem_area_2"": null,
                      ""brand_id"": null
                    },
                    ""_links"": {
                      ""self"": {
                        ""href"": ""\/api\/v2\/cases\/1"",
                        ""class"": ""case""
                      },
                      ""message"": {
                        ""href"": ""\/api\/v2\/cases\/1\/message"",
                        ""class"": ""email""
                      },
                      ""customer"": {
                        ""href"": ""\/api\/v2\/customers\/287193532"",
                        ""class"": ""customer""
                      },
                      ""labels"": {
                        ""href"": ""\/api\/v2\/cases\/1\/labels"",
                        ""class"": ""label""
                      },
                      ""assigned_user"": {
                        ""href"": ""\/api\/v2\/users\/22787152"",
                        ""class"": ""user""
                      },
                      ""assigned_group"": {
                        ""href"": ""\/api\/v2\/groups\/474802"",
                        ""class"": ""group""
                      },
                      ""locked_by"": null,
                      ""history"": {
                        ""href"": ""\/api\/v2\/cases\/1\/history"",
                        ""class"": ""history""
                      },
                      ""case_links"": {
                        ""href"": ""\/api\/v2\/cases\/1\/links"",
                        ""class"": ""case_link"",
                        ""count"": 0
                      },
                      ""macro_preview"": {
                        ""href"": ""\/api\/v2\/cases\/1\/macros\/preview"",
                        ""class"": ""macro_preview""
                      },
                      ""replies"": {
                        ""href"": ""\/api\/v2\/cases\/1\/replies"",
                        ""class"": ""reply"",
                        ""count"": 1
                      },
                      ""draft"": {
                        ""href"": ""\/api\/v2\/cases\/1\/replies\/draft"",
                        ""class"": ""reply""
                      },
                      ""notes"": {
                        ""href"": ""\/api\/v2\/cases\/1\/notes"",
                        ""class"": ""note"",
                        ""count"": 0
                      },
                      ""attachments"": {
                        ""href"": ""\/api\/v2\/cases\/1\/attachments"",
                        ""class"": ""attachment"",
                        ""count"": 0
                      }
                    }
                  }
                ]
              }
            }";
            var deserializeObject = JsonConvert.DeserializeObject<Rootobject>(str);
            Console.WriteLine(deserializeObject.total_entries);
        }
    }
    public class Rootobject
    {
        public int total_entries { get; set; }
        public int page { get; set; }
        public _Links _links { get; set; }
        public _Embedded _embedded { get; set; }
    }
    public class _Links
    {
        public Self self { get; set; }
        public First first { get; set; }
        public Last last { get; set; }
        public object previous { get; set; }
        public Next next { get; set; }
    }
    public class Self
    {
        public string href { get; set; }
        public string _class { get; set; }
    }
    public class First
    {
        public string href { get; set; }
        public string _class { get; set; }
    }
    public class Last
    {
        public string href { get; set; }
        public string _class { get; set; }
    }
    public class Next
    {
        public string href { get; set; }
        public string _class { get; set; }
    }
    public class _Embedded
    {
        public Entry[] entries { get; set; }
    }
    public class Entry
    {
        public int id { get; set; }
        public object external_id { get; set; }
        public string blurb { get; set; }
        public int priority { get; set; }
        public object locked_until { get; set; }
        public object[] label_ids { get; set; }
        public string active_at { get; set; }
        public string changed_at { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string first_opened_at { get; set; }
        public string opened_at { get; set; }
        public string first_resolved_at { get; set; }
        public string resolved_at { get; set; }
        public string status { get; set; }
        public int active_notes_count { get; set; }
        public int active_attachments_count { get; set; }
        public bool has_pending_interactions { get; set; }
        public bool has_failed_interactions { get; set; }
        public object description { get; set; }
        public object language { get; set; }
        public string received_at { get; set; }
        public string type { get; set; }
        public object[] labels { get; set; }
        public string subject { get; set; }
        public string route_status { get; set; }
        public Custom_Fields custom_fields { get; set; }
        public _Links1 _links { get; set; }
    }
    public class Custom_Fields
    {
        public object exclude_portal { get; set; }
        public object exclude_notifications { get; set; }
        public object case_type { get; set; }
        public object product { get; set; }
        public object severity { get; set; }
        public object knowledge_status { get; set; }
        public object desk_case_id { get; set; }
        public object sla_status { get; set; }
        public object priority { get; set; }
        public object sla_violation { get; set; }
        public object sla_milestone_completed { get; set; }
        public object sync_to_salesforce { get; set; }
        public object _7616_pa2 { get; set; }
        public object _7643_pa1 { get; set; }
        public object _7714_pa1 { get; set; }
        public object _7616_pa1 { get; set; }
        public object _7643_pa2 { get; set; }
        public object _7714_pa2 { get; set; }
        public object entitlement_name { get; set; }
        public object escalation_level { get; set; }
        public object testing { get; set; }
        public object defect_number { get; set; }
        public object channel { get; set; }
        public object product_version { get; set; }
        public object exclude_from_reporting { get; set; }
        public object cw_id { get; set; }
        public object desk_agent_id { get; set; }
        public object desk_agent_name { get; set; }
        public object solution_codes { get; set; }
        public object _7723_pa2 { get; set; }
        public object _7670_pa2 { get; set; }
        public object _7661_pa1 { get; set; }
        public object _7634_pa2 { get; set; }
        public object _7670_pa1 { get; set; }
        public object _7758_pa1 { get; set; }
        public object _7634_pa1 { get; set; }
        public object _7688_pa1 { get; set; }
        public object _7723_pa1 { get; set; }
        public object _7688_pa2 { get; set; }
        public object _7661_pa2 { get; set; }
        public object _7758_pa2 { get; set; }
        public object _7697_pa1 { get; set; }
        public object problem_area_1 { get; set; }
        public object problem_area_2 { get; set; }
        public object spam { get; set; }
        public object salesforce_problem_area_1 { get; set; }
        public object salesforce_problem_area_2 { get; set; }
        public object brand_id { get; set; }
    }
    public class _Links1
    {
        public Self1 self { get; set; }
        public Message message { get; set; }
        public Customer customer { get; set; }
        public Labels labels { get; set; }
        public Assigned_User assigned_user { get; set; }
        public Assigned_Group assigned_group { get; set; }
        public object locked_by { get; set; }
        public History history { get; set; }
        public Case_Links case_links { get; set; }
        public Macro_Preview macro_preview { get; set; }
        public Replies replies { get; set; }
        public Draft draft { get; set; }
        public Notes notes { get; set; }
        public Attachments attachments { get; set; }
    }
    public class Self1
    {
        public string href { get; set; }
        public string _class { get; set; }
    }
    public class Message
    {
        public string href { get; set; }
        public string _class { get; set; }
    }
    public class Customer
    {
        public string href { get; set; }
        public string _class { get; set; }
    }
    public class Labels
    {
        public string href { get; set; }
        public string _class { get; set; }
    }
    public class Assigned_User
    {
        public string href { get; set; }
        public string _class { get; set; }
    }
    public class Assigned_Group
    {
        public string href { get; set; }
        public string _class { get; set; }
    }
    public class History
    {
        public string href { get; set; }
        public string _class { get; set; }
    }
    public class Case_Links
    {
        public string href { get; set; }
        public string _class { get; set; }
        public int count { get; set; }
    }
    public class Macro_Preview
    {
        public string href { get; set; }
        public string _class { get; set; }
    }
    public class Replies
    {
        public string href { get; set; }
        public string _class { get; set; }
        public int count { get; set; }
    }
    public class Draft
    {
        public string href { get; set; }
        public string _class { get; set; }
    }
    public class Notes
    {
        public string href { get; set; }
        public string _class { get; set; }
        public int count { get; set; }
    }
    public class Attachments
    {
        public string href { get; set; }
        public string _class { get; set; }
        public int count { get; set; }
    }
