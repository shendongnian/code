        Public bool GenerateInvoice(Invoice invoice, List<TimeSheet> timesheets)
        {
            bool ret = false;
            using (DataContext dc = new DataContext())
            {
                foreach (var item in timesheets)
                {
                    TimeSheet ts = dc.GetTimesheetById(item.Id);
                    invoice.TimeSheets.Add(ts);
                }
                dc.Invoices.Add(invoice);
                dc.SaveChanges();
                ret = true;
            }
            return ret;
        }
