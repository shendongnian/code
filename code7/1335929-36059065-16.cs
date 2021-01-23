    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using FluentNHibernate.Mapping;
    
    namespace TelerikMvcApp1.Models
    {
        public class GenreMap : ClassMap <Genre>
        {
                public GenreMap()
                {
                    Id(x => x.GenreId).Column("Id");
                    Map(x => x.Name);
                    Map(x => x.Description);
                    Table("Genres");
                }
            
        }
    }
