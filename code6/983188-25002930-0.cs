    public List<SupplierView> Find(string name)
        {
            using (var suppre = new SupplierRepository())
            {
                return suppre.Find(x => x.Supplier_Name == name).Select(x => new SupplierView()
                {
                    Supplier_Id = x.Supplier_Id,
                    Supplier_Name = x.Supplier_Name,
                    Supplier_Address = x.Supplier_Address,
                    Email = x.Email,
                    Contact_No = x.Contact_No,
                    Contact_Person = x.Contact_Person,
                    Type_of_medicine = x.Type_of_medicine,
                    Product_ID = x.Product_ID
                }).ToList();
            }
        }
