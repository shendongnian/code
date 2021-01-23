    public void Counting()
            {
                foreach (Order k in db.OrderItems)
                {
                    int sum = 0;
                    Statystyki temp = new Statystyki();
                    foreach (Product product in db.Products)
                    {
    
                        if (product.Id == k.productId)
                        {
                            sum += k.quantity;
                        }
                    }
    
                    temp.Nazwa = k.Product.Name;
                    if (!lista_statystyk.Exists(x => string.Compare(x.Nazwa, temp.Nazwa, true) == 0))
                    {
    
                        temp.suma = sum;
                        lista_statystyk.Add(temp);
                    }
                    else if (lista_statystyk.Exists(x => string.Compare(x.Nazwa, temp.Nazwa, true) == 0))
                    {
                        temp.suma += sum;
                        lista_statystyk.Add(temp);
                    }
                }
            }
