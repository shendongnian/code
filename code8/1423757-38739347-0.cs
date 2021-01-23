            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
            decimal.TryParse(first, System.Globalization.NumberStyles.Currency,
                                 ci, out firstNumber);
           decimal.TryParse(second, System.Globalization.NumberStyles.Currency,
                                ci, out secondNumber);
