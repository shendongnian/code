    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using OnlineShoppingStore.Domain.Abstract;
    using PagedList;
    using PagedList.Mvc;
    using OnlineShoppingStore.WebUI.Models;
    namespace OnlineShoppingStore.WebUI.Controllers
    {
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(int? page, string category, string Filter_Value)
        {
            if (category != null)
            {
                page = 1;
            }
            else
            {
                category = Filter_Value;
            }
            ViewBag.FilterValue = category;
            ProductListViewModel model = new ProductListViewModel
            {
                Prodcuts = repository.Products
                    .Where(p => category == null || p.Category == category),
                CurrentCategory = category
            };
            
                     return View (model.Prodcuts.ToList().ToPagedList(page ?? 1, 3));
            
               }
        
           }
     }
