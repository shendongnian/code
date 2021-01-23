                {
                    s.Prefix = SavingsIndicator.GreatSavings.AsString();
                }
                else if (s.GDSDollarSavings >= 100 && s.GDSDollarSavings < 500)
                {
                    s.Prefix = SavingsIndicator.GoodSavings.AsString();
                }
                else
                {
                    s.Prefix = SavingsIndicator.OKSavings.AsString();
                }
