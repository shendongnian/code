    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString QuestionCategoryColor(this HtmlHelper helper, QuestionCategory category)
        {
            string color = "";
            switch (category)
            {
                case Core.Data.Models.QuestionCategory.Overall: color = "#10c469"; break;
                case Core.Data.Models.QuestionCategory.Service: color = "#f9c851"; break;
                case Core.Data.Models.QuestionCategory.Facilities: color = "#188ae2"; break;
                case Core.Data.Models.QuestionCategory.Team: color = "#5b69bc"; break;
             }
    
            return MvcHtmlString.Create(color);
        }
    }
