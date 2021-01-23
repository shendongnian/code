     [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create( VMSalesman vmsalesman)
            {
                if (ModelState.IsValid)
                {
                    List<Customer> list = new List<Customer>();
                    for (int i = 0; i < vmsalesman.CustomerList.Count; i++)
                    {
                        if (vmsalesman.CustomerList[i].IsSelected==true)
                        {
                            int n = vmsalesman.CustomerList[i].VMCustomerID;
                            list.Add(db.Customers.Where(c => c.CustomerID == n).First());
                        }   
                    }
                    Salesman salesman = new Salesman() {
                        Name = vmsalesman.Name,
                        LastName = vmsalesman.LastName,
                        Location = vmsalesman.Location,
                        CustomersList = list
                    };
                    db.Salesmen.Add(salesman);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(vmsalesman);
            }
