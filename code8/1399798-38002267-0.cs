    var products = db.PRODUCT_PROCEDURE(username)
                    .Where
                            (item => (item.basedescription ?? "").Contains(searchword) 
                             || (item.info ?? "").Contains(searchword)
                             || (item.itemno ?? "").Contains(searchword)
                             || (item.itemno ?? "").Contains(searchword.Replace("-", ""))
                             || (item.upc ?? "").Contains(searchword)).ToList();
