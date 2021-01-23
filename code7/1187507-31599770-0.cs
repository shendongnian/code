    namespace Model
    {
        public class Language
        {
            public static implicit operator Model.Language(DAL.Language language)
            {
                return new Model.Language()
                {
                    /* map values here */
                }
            }
            public static implicit operator DAL.Language(Model.Language language)
            {
                return new DAL.Language()
                {
                    /* map values here */
                }
            }
        }
    }
