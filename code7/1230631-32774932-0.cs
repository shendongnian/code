            {
                
                if (customers[temp] != null) continue;
                    {
                    for (int indexies = 0; indexies < customers.Length; indexies++)
                    {
                        
                            var R1 = new Random();
                            var R2 = new Random();
                            Convert.ToInt32(createPin.Text);
                            customers[temp] = new Accounts();
                            customers[temp].Name = newName.Text;
                            customers[temp].accountType = newAccountType;
                        customers[temp].accountNumber = 1;//(R1.Next(1000000, 9000000)) + (R2.Next(100, 9000));
                            customers[temp].accountPin = Convert.ToInt32(createPin.Text);
                            customers[temp].accountBalance = 100.00;
                            added = true;
                        
                        
                    }
                        
                        
                    }
                    
                }
