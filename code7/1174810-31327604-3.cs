    private void DatePicker_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Enter)
                {
                    List<JobCostEntity> tempList = (List<JobCostEntity>)dg.ItemsSource;
                    tempList.Add(new JobCostEntity() { InvoiceDate = ((DatePicker)sender).DisplayDate });
                    dg.ItemsSource = tempList;
                }
            }
