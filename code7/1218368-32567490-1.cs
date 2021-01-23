    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using OnlineShoppingStore.Domain.Entities;
 
    namespace OnlineShoppingStore.WebUI.Models
    {
    public class ProductListViewModel
    {
        public  IEnumerable <Product> Prodcuts { get; set; } 
        public  string CurrentCategory { get; set; }
       
    }
    }
