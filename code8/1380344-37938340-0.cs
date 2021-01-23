    config.Routes.MapHttpRoute("GetRiskReports", "Members/{id}/Cpin/RiskReports" ,
          new {
                 controller = "Members",
                 action = "GetRiskReports"
          },
          new {
                HttpMethod = new HttpMethodConstraint(HttpMethod.Get)
           }
    );
    config.Routes.MapHttpRoute("PostRiskReports", "Members/{id}/Cpin/RiskReports" ,
          new {
                 controller = "Members",
                 action = "PostRiskReports"
          },
          new {
                HttpMethod = new HttpMethodConstraint(HttpMethod.Post)
           }
    );
