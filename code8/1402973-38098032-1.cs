    Model[] models = new []{
        new Model {
            project_name = "Mailjet Support",
            cluster_name = "24/7 Support",
            is_billable = "1",
            usedtime = "128"
        },               
        new Model{                
            project_name = "Caring",
            cluster_name = "Caring",
            is_billable = "0",
            usedtime = "320"
        },             
        new Model{               
            project_name = "Engagement",
            cluster_name = "Community",
            is_billable = "0",
            usedtime = "8"
        }
    };
    string mockJsonResponse = Newtonsoft.Json.JsonConvert.SerializeObject(models);
