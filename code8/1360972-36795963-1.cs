        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "A",
                "ZZZ/A/{id}",
                new { controller = "My", action = "Detail_Index", id = UrlParameter.Optional }
            );
        }
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "B",
                "ZZZ/B/{id}",
                new { controller = "My", action = "Detail_Index", id = UrlParameter.Optional }
            );
        }
