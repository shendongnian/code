        private DataTable dummyTable = new DataTable("DUMMY");
        private bool searchOrders(IProgressor pProgressor, object pState)
        {
            int count = AppDocument.Instance.SearchOrders(this.searchFields, AppDocument.ESearchOptions.EstimateOnly);
            if (count > 1000)
            {
                DialogResult dr = MessageBox.Show(Languages.TranslateFmt("{0} orders found, loading may take time. Do you want to continue?", count),
                    Languages.Translate("Confirm"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == System.Windows.Forms.DialogResult.Cancel) return true;
            }
            displaySearchResultsDgv(dgvOrdersList, this.dummyTable);
            Thread.Sleep(10);
            
            AppDocument.Instance.SearchOrders(this.searchFields, (this.joinToLoaded ? AppDocument.ESearchOptions.Join : AppDocument.ESearchOptions.None));
            updateStatusLabs(
                Languages.Translate("Displaying..."),
                Languages.TranslateFmt("+ {0} orders found...", AppDocument.Instance.SearchResults.Rows.Count));
            displaySearchResultsDgv(dgvOrdersList, AppDocument.Instance.SearchResults);
            return true;
        }
