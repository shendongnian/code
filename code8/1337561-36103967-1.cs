            using (MyEntities context = new MyEntities())
            {
                TAX tax = new TAX();
                tax.TAX1 = decimal.Parse(tbTax.Text);
                context.TAXs.Add(tva);
                context.SaveChanges();
                tbTax.Text = "";
                dbgrid.ItemsSource = db.TAXs.ToList();
            }
