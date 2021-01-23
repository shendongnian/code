     // GET: Deliveries/Edit
    public ActionResult Edit(int? id){   
        db.Configuration.ProxyCreationEnabled = false;
            DeliveryEditViewModel model = db.Deliveries.Include(s => s.Supplier).Include(a => a.Auction).Include(q => q.Quality).Include(t => t.BulbType)
                    .Where(d => d.DeliveryID == id)
                    .Select(x => new DeliveryEditViewModel{
                        DeliveryID = x.DeliveryID,
                        SelectedCompanyName = x.Supplier.CompanyName
                    })
                    .Single();               
        Model.suppliers = db.Suppliers.Where(s => s.IsActive == true);
        return View(model);
    }
