                if (oItem.GetByKey(ItemCode) == true)
                {
                    oItem.PriceList.SetCurrentLine(Index);
                    oItem.PriceList.Price = 1000;
                }
                    oItem.Update();
       
                int ErrNo;
                string errMsg;
                errMsg = SAP_Company.GetLastErrorDescription();
                ErrNo = SAP_Company.GetLastErrorCode();
                if (ErrNo != 0)
                {
                    MessageBox.Show(ErrNo + ": " + errMsg);
                }
                else
                {
                    MessageBox.Show("Nice!");
                }
