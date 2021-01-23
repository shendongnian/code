        //for data generation
        static Random rdn = new Random();
        //some list to hold data
        List<clsDataStruct.ItemType> lstItemType = new List<clsDataStruct.ItemType>();
        List<clsDataStruct.Item> lstItem = new List<clsDataStruct.Item>();
        List<clsDataStruct.BillByItem> lstBill = new List<clsDataStruct.BillByItem>();
        //this is what user choose to filter the report
        //user choose to report which item type
        List<clsDataStruct.ItemType> lstItemTypeByUser = new List<clsDataStruct.ItemType>();
        //date begin and end of report
        DateTime dteStart;
        DateTime dteEnd;
        private void Form1_Load(object sender, EventArgs e)
        {
            //create 3 ItemType
            for (int i = 1; i < 4; i++)
            {
                clsDataStruct.ItemType itt = new clsDataStruct.ItemType();
                itt.Name = "Item Type " + i.ToString();
                lstItemType.Add(itt);
            }
            //create 12 Item
            for (int i = 1; i < 13; i++)
            {
                clsDataStruct.Item item = new clsDataStruct.Item();
                item.Name = "Item " + i.ToString();
                item.Type = lstItemType[i % 3];
                item.Cost = rdn.Next(10);
                item.Prize = item.Cost + rdn.Next(5);
                lstItem.Add(item);
            }
            //create 30 BillByItem in next 3 month
            for (int i = 1; i < 31; i++)
            {
                clsDataStruct.BillByItem bill = new clsDataStruct.BillByItem();
                bill.DateSold = DateTime.Now.AddDays(rdn.Next(90));
                bill.Item = lstItem[rdn.Next(12)];
                lstBill.Add(bill);
            }
            //set the filters
            //add 2 random type to the filter
            lstItemTypeByUser.Add(lstItemType.Where(s => !lstItemTypeByUser.Contains(s)).ToList()[rdn.Next(lstItemType.Where(s => !lstItemTypeByUser.Contains(s)).ToList().Count)]);
            lstItemTypeByUser.Add(lstItemType.Where(s => !lstItemTypeByUser.Contains(s)).ToList()[rdn.Next(lstItemType.Where(s => !lstItemTypeByUser.Contains(s)).ToList().Count)]);
            //date start and end is one month from date we have data
            dteStart = DateTime.Now.AddDays(rdn.Next(60) - 30);
            dteEnd = DateTime.Now.AddMonths(3).AddDays(rdn.Next(60) - 30);
            this.reportViewer1.LocalReport.DataSources.Clear();
            dsReports.dtLyLichTrichNgangDataTable dtLyLichTrichNgang = new dsReports.dtLyLichTrichNgangDataTable();
            //Simple title, replace with yours
            dtLyLichTrichNgang.Rows.Add("ITEM INVENTORY SOLD " + dteStart.ToShortDateString() + " - " + dteEnd.ToShortDateString(), "", "", "", "", "", "");
            //empty row
            dtLyLichTrichNgang.Rows.Add(" ", "", "", "", "", "", "");
            DateTime dteFirstOfCycle;
            DateTime dteLastOfCycle;
            //cycle through months and fill data to datatable, maybe week or quarter
            for (dteFirstOfCycle = new DateTime(dteStart.Year, dteStart.Month, 1); dteFirstOfCycle < dteEnd; dteFirstOfCycle = dteFirstOfCycle.AddMonths(1))
            {
                dteLastOfCycle = dteFirstOfCycle.AddMonths(1).AddDays(-1);
                //take BillByItem in each month
                var billMonth = lstBill.Where(s => s.DateSold >= dteFirstOfCycle && s.DateSold <= dteLastOfCycle).OrderBy(s => s.DateSold);
                dtLyLichTrichNgang.Rows.Add("FROM " + dteFirstOfCycle.ToShortDateString() + " TO " + dteLastOfCycle.ToShortDateString(), "", "", "", "", "", "");
                //empty row
                dtLyLichTrichNgang.Rows.Add(" ", "", "", "", "", "", "");
                //cycle through each item type
                foreach (clsDataStruct.ItemType itt in lstItemTypeByUser)
                    //have sold something
                    if (billMonth.Where(s => s.Item.Type == itt).Count() != 0)
                    {
                        //itemtype
                        dtLyLichTrichNgang.Rows.Add(itt.Name.ToUpper(), "", "", "", "", "", "");
                        //detail header
                        dtLyLichTrichNgang.Rows.Add("", "", "Name", "Cost", "Prize", "Profit", "Date Sold");
                        //cycle through each bill
                        foreach (clsDataStruct.BillByItem bill in billMonth)
                            dtLyLichTrichNgang.Rows.Add("", "", bill.Item.Name, bill.Item.Cost, bill.Item.Prize, bill.Item.Prize - bill.Item.Cost, bill.DateSold.ToShortDateString());
                        //total row
                        dtLyLichTrichNgang.Rows.Add("", "", "TOTAL", billMonth.Sum(s => s.Item.Cost), billMonth.Sum(s => s.Item.Prize), billMonth.Sum(s => s.Item.Prize - s.Item.Cost), "");
                    }
                    //sold nothing
                    else
                    {
                        dtLyLichTrichNgang.Rows.Add(itt.Name.ToUpper(), "", "", "", "", "", "");
                        dtLyLichTrichNgang.Rows.Add("Nothing sold", "", "", "", "", "", "");
                        //empty row
                        dtLyLichTrichNgang.Rows.Add(" ", "", "", "", "", "", "");
                    }
                //empty row
                dtLyLichTrichNgang.Rows.Add(" ", "", "", "", "", "", "");
            }
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsLyLichTrichNgang", (DataTable)dtLyLichTrichNgang));
            this.reportViewer1.RefreshReport();
        }
