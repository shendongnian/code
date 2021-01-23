    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    
    namespace FormsTagHelper.ViewModels
    {
        public class CountryViewModel
        {
            public string Country { get; set; }
    
            public List<SelectListItem> Countries { get; set; }
        }
    }
