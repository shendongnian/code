    public static class QuestionCategoryExtensions
    {
        public static string ToColor(this QuestionCategory category)
        {
                switch (category)
                {
                    case QuestionCategory.Overall: return  "#10c469"; 
                    case QuestionCategory.Service: return "#f9c851";
                    case QuestionCategory.Facilities: return "#188ae2"; 
                    case QuestionCategory.Team: return "#5b69bc"; 
                }
                return string.Empty;
            }
        }
    }
