       foreach (var node in doc.DocumentNode.SelectNodes("//div[@class='g2 bp_l_1of4 bp_m_1of3 bp_s_1of2 bp_xs_1of1 item  ']"))
            {
                Products p = new Product();
                p.ProductName = node.SelectSingleNode(".//span[@class='item_title']").InnerText;
                p.ProductPrice = node.SelectSingleNode(".//span[@class='price']").InnerText;
        
                 db.Products.Add(p);
        
            }
        db.SaveChanges();
