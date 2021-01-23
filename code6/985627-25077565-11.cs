        private void my_SetSelectedItemBasedOnQuantity(ListPicker lp, int quantity)
        {
            // first search for quantity if a match is found set it
            try
            {
                foreach (ListQuantityClass lqc in lp.ItemsSource)
                {
                    // match found
                    if (lqc.Quantity == quantity)
                    {
                        lp.SelectedItem = lqc;
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
