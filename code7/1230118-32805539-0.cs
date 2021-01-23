    public class Case
    {
        public Case(IPublishedContent content) 
        {
            Id = content.Id;
            Description = content.GetPropertyValue<string>("description");
            Title = content.GetPropertyValue<string>("title");
            //image
            string image = content.GetPropertyValue<string>("image");            
            int imageId = 0;
            int.TryParse(image, out imageId);
            if (imageId != 0)
            {
                
                    var umbracoHelper = new Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current);
                    Image = umbracoHelper.Media(imageId).GetCropUrl("umbracoFile", "image");          
            }
            //Team
            string teamID = content.GetPropertyValue<string>("teamMember");
            Team = DAL.GetTeamProperties(teamID);
        }
        public Case() { }
        public int Id { get; set; } 
        public string Title { get; set; }            
        public string Description { get; set; }
        public string Image { get; set; }
        public List<Team> Team { get; set; }
    }
